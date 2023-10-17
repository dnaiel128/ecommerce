import { authStore } from '@/stores/auth.store.js';

export const fetchWrapper = {
    get: request('GET'),
    post: request('POST'),
    put: request('PUT'),
    delete: request('DELETE')
};

function request(method) {
    return (url, body) => {
        const requestOptions = {
            method,
            headers: authHeader(url)
        };
        if (body) {
            requestOptions.headers['Content-Type'] = 'application/json';
            requestOptions.body = JSON.stringify(body);
        }
        return fetch(url, requestOptions).then(handleResponse);
    }
}

// helper functions

function authHeader(url) {
    // return auth header with jwt if user is logged in and request is to the api url
    const { user } = authStore();
    const isLoggedIn = !!user;
    const isApiUrl = url.startsWith(import.meta.env.backendUrl);
    if (isLoggedIn && isApiUrl) {
        return { Authorization: `Bearer ${user}` };
    } else {
        return {};
    }
}

function handleResponse(response) {
    return response.text().then(text => {

        const data = text ;//&& JSON.parse(text);
        
        if (!response.ok) {
            const { user, redirectToErrorPage } = authStore();
            if ([401, 403].includes(response.status) && user) {
                // auto logout if 401 Unauthorized or 403 Forbidden response returned from api
                // redirect to home page, for my case
                redirectToErrorPage(response.status);
            }

            const error = (data && data.message) || response.statusText;
            return Promise.reject(error);
        }

        return data;
    });
}    
