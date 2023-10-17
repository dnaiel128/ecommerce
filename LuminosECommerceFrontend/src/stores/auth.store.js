import { defineStore } from 'pinia';

import { fetchWrapper } from '@/helpers/fetch-wrapper';

import  router  from '@/router/index'

const baseUrl = `${import.meta.env.VITE_API_URL}/user`;

export const authStore = defineStore({
    id: 'auth',
    state: () => ({
        // initialize state from local storage to enable user to stay logged in
        user: JSON.parse(localStorage.getItem('user')),
        returnUrl: null
    }),
    actions: {
        async login(username, password) {
            const user = await fetchWrapper.post(`${baseUrl}/login`, { username, password });

            // update pinia state
            this.user = user;

            // store user details and jwt in local storage to keep user logged in between page refreshes
            // this only stores the jwt of a user in local storage
            localStorage.setItem('user', JSON.stringify(user));
            
            console.log("login was successfull");

            // redirect to previous url or default to home page
            window.location.href = 'http://localhost:5173/';
            //router.push('http://localhost:5173/');
        },

        async register(username, password, firstName, lastName, isAdmin){
            const newUser = await fetchWrapper.post(`${baseUrl}/register`, { username, password, firstName, lastName, isAdmin });

            //push to login page
            router.push({name:'LoginView'});
        },

        logout() {
            this.user = null;
            localStorage.removeItem('user');
            router.push({name:'Catalog'});
        },

        redirectHome() {
            router.push({name:'Catalog'})
        },

        redirectToErrorPage(status){
            router.push({name:'ErrorView', params: {status}})
        }
    }
});
