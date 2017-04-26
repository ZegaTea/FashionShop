var update = {
    init: function () {
        update.events();
    },
    events: function () {
        var Domain = 'http://' + location.hostname + ':' + location.port;
        $('#btnUpdateProduct').off('click').on('click', function () {
            $.ajax({
                data: {
                    product: {
                        maSanPham: $('.ma').val(),
                        moTa: $('.mota').text(),
                        giaSanPham: $('.gia').val(),
                        chatLieu: $('.chatlieu').val(),
                        soLuongDatMua: $('.sl').val(),
                        mauSac: $('.mau').val(),
                        urlAnh: $(this).attr('url'),
                        ngayTao: $('.ngaytao').val(),
                        tenSanPham: $('.ten').val(),
                        loaiSanPhamMa: $('.tenloai').val()
                    }

                },
                url: Domain + '/Admin/Product/UpdateProduct',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert("Cập nhật thông tin sản phẩm thành công")
                    }
                }
            })
        });

        $('#btnUpdateGroupPr').off('click').on('click', function () {
            $.ajax({
                data: {
                    maNhom: $('#ma').val(),
                    tenNhom: $('#ten').val(),
                    tittle: $('#tittle').val()
                },
                url: Domain + '/Admin/Group/UpdateGroupPr',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert("Cập nhật thông tin nhóm sản phẩm thành công")
                    }
                }
            })
        });
    }

}

update.init();