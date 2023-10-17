export default {
    setup() {},
    template: `
    <div>
        <table class="table">
            <thead>
                <tr class="table-secondary">
                    <th>
                        Name
                    </th>
                    <th>
                        Desc
                    </th>
                    <th>
                        Price
                    </th>
                    <th>
                        Path
                    </th>

                </tr>
            </thead>
            <tbody>
                <tr v-for="item in this.products">
                    <td>
                        {{item.Name}}
                    </td>
                    <td>
                        {{item.Description}}
                    </td>
                    <td>
                        {{item.Price}}
                    </td>
                    <td>
                        {{item.ImageFolderPath}}
                    </td>
                </tr>
                }
            </tbody>
        </table>
    </div>`
}