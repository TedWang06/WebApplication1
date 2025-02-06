( function () {

    init();

    function init() {

        const VueApp = {
            data() {
                return {
                    isEdit : false ,
                    customers: [],
                    editItem: {}
                }
            },
            methods: {
                resetData: resetData,
                deleteButton: deleteButton,
                editButton: editButton,
                saveButton: saveButton
            },
            mounted() {
                this.resetData();
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

    function resetData() {
        const vm = this;
        getInitData().then( ( result ) => {
            vm.customers = result;
        } );         
    }

    function deleteButton( item ) {
        const vm = this;
        if ( confirm( '確認刪除' + item.CompanyName + '?' ) ) {        
            axios( {
                method: 'post',
                url: 'api/Customers/DeleteCustomer',
                data: JSON.stringify( item.CustomerId ),
                headers: { 'Content-Type': 'application/json' } 
            } ).then( response => {
                if ( response.data == - 1 ) {
                    alert( '刪除成功' );
                    //畫面處理/資料重撈
                    vm.resetData();
                }
            } )
        }
    }

    function editButton( item ) {
        this.isEdit = true;
        this.editItem = { ...item } ;
    }

    function saveButton() {
        const vm = this;
        const data = this.editItem;
        debugger;
        axios( {
            method: 'post',
            url: 'api/Customers/EditCustomer',
            data: JSON.stringify(data),
            headers: { 'Content-Type': 'application/json' }
        } ).then( response => {
            if ( response.data ) {
                debugger;
                alert( '編輯成功' );
                //畫面處理/資料重撈
                vm.isEdit = false;
                vm.resetData();
            }
        } )

    }

} )();