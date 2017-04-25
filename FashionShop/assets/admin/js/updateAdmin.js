var update = {
    init: function () {
        update.events();
    },
    events: function () {
        $('#btnUpdateProduct').off('click').on('click', function () {
            $.ajax({
                url: '/Admin/Product/UpdateProduct',
                data: {
                    product: {
                        maSanPham: $('#ma').val(),
                        moTa: $('#mota').val,
                        giaSanPham: $('#gia').val,
                        chatLieu: $('#chatlieu').val(),
                        soLuongDatMua: $('#sl').val,
                        mauSac: $('#mau').val(),
                        urlAnh: $(this).attr('url'),
                        ngayTao: $('#ngaytao').val(),
                        tenSanPham: $('#ten').val(),
                        loaiSanPhamMa: $('#tenloai').val()
                    }
                },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert("Cập nhật thông tin sản phẩm thành công")
                    }
                }
            })
        });
    }

}

update.init();