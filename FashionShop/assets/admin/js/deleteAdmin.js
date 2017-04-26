var deleteAdmin = {
    init: function(){
        deleteAdmin.events();
    },

    events: function () {
        var Domain = 'http://' + location.hostname + ':' + location.port;
        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: {
                    maSanPham: $(this).data('id')
                },
                url: Domain + '/Admin/Product/DeleteProduct',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert("Xóa sản phẩm thành công");
                        window.location.href = "/Admin/Product/Index"
                    }
                }
            })
        });
    }
}

deleteAdmin.init();
