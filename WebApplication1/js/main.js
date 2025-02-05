( function () {

    init();

    function init() {

        const VueApp = {
            data() {
                return {
                    message: ' Vue!'
                }
            },
            mounted() {
                getInitData();
            }
        }

        Vue.createApp( VueApp ).mount( '#app' );
    }

    async function getInitData() {
        debugger;
        try {
            const response = await axios.get( 'api/Customers' );
            debugger;
        }
        catch ( e ) {
            alert( 'get data error' );
        }
    }

} )();