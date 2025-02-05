( function () {

    init();

    function init() {

        const VueApp = {
            data() {
                return {
                    message: ' Vue!',
                    customers : []
                }
            },
            mounted() {
                getInitData().then( ( result )  => {
                    this.customers = result;
                } );                
            }
        }

        Vue.createApp( VueApp ).mount( '#app' );
    }

    async function getInitData() {
        try {
            const response = await axios.get( 'api/Customers' );
            return response.data;
        }
        catch ( e ) {
            alert( 'get data error' );
        }
    }

} )();