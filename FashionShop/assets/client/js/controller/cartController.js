var cart = {
    init: function () {
        cart.events();
    },
    events: function () {
        $('#btnAddCart').off('click').on('click', function () {
            var cartList = {
                size: $('#cmbSize').val(),
                soLuong: $('.txtSoLuong').val(),
                product: {
                    maSanPham: $('#idSanPham').text()
                }
            };


            $.ajax({
                url: '/Product/AddCart',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert("Thêm giỏ hàng thành công");
                    }
                }
            })
        });

        $('.btn-danger').off("click").on('click', function () {
            $.ajax({
                data: { maSanPham: $(this).attr('ma'), size: $(this).attr('size') },
                url: '/Cart/DeleteItem',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = '/gio-hang';
                    }
                }
            })
        });
    }
}

cart.init();