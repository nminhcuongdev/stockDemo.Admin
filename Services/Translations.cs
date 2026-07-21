namespace StockDemo.Admin.Services;

/// <summary>Static vi/en string table used by <see cref="LocalizationService"/>.</summary>
public static class Translations
{
    public static string Get(string culture, string key)
    {
        if (Map.TryGetValue(key, out var pair))
        {
            return culture == "en" ? pair.En : pair.Vi;
        }
        return key; // Fallback: show the key so missing translations are obvious.
    }

    private readonly record struct Pair(string Vi, string En);

    private static readonly Dictionary<string, Pair> Map = new()
    {
        // App shell / nav
        ["app.title"] = new("StockDemo Admin", "StockDemo Admin"),
        ["app.subtitle"] = new("Quản trị dữ liệu kho", "Warehouse data administration"),
        ["app.logout"] = new("Đăng xuất", "Log out"),
        ["nav.dashboard"] = new("Tổng quan", "Dashboard"),
        ["nav.catalog"] = new("Danh mục", "Catalog"),
        ["nav.products"] = new("Sản phẩm", "Products"),
        ["nav.locations"] = new("Vị trí kho", "Locations"),
        ["nav.warehouse"] = new("Kho vận", "Warehouse"),
        ["nav.stocks"] = new("Tồn kho", "Stock on hand"),
        ["nav.stockIns"] = new("Nhập kho", "Stock in"),
        ["nav.stockOuts"] = new("Xuất kho", "Stock out"),
        ["nav.transfers"] = new("Điều chuyển", "Transfers"),
        ["nav.deliveryOrders"] = new("Đơn giao hàng", "Delivery orders"),
        ["nav.lowStock"] = new("Cảnh báo tồn thấp", "Low-stock alerts"),
        ["nav.reportsSystem"] = new("Báo cáo & Hệ thống", "Reports & System"),
        ["nav.reports"] = new("Báo cáo tồn kho", "Stock reports"),
        ["nav.users"] = new("Người dùng", "Users"),

        // Common
        ["common.add"] = new("Thêm", "Add"),
        ["common.edit"] = new("Sửa", "Edit"),
        ["common.delete"] = new("Xóa", "Delete"),
        ["common.save"] = new("Lưu", "Save"),
        ["common.saving"] = new("Đang lưu...", "Saving..."),
        ["common.cancel"] = new("Hủy", "Cancel"),
        ["common.search"] = new("Tìm kiếm...", "Search..."),
        ["common.actions"] = new("Thao tác", "Actions"),
        ["common.status"] = new("Trạng thái", "Status"),
        ["common.active"] = new("Hoạt động", "Active"),
        ["common.inactive"] = new("Ngừng", "Inactive"),
        ["common.confirmDeleteTitle"] = new("Xác nhận xóa", "Confirm delete"),
        ["common.loading"] = new("Đang tải...", "Loading..."),
        ["common.date"] = new("Ngày", "Date"),
        ["common.quantity"] = new("Số lượng", "Quantity"),
        ["common.createdBy"] = new("Người tạo", "Created by"),
        ["common.dateRange"] = new("Khoảng thời gian", "Date range"),
        ["common.product"] = new("Sản phẩm", "Product"),
        ["common.location"] = new("Vị trí", "Location"),
        ["common.rowsPerPage"] = new("Số dòng mỗi trang:", "Rows per page:"),

        // Login
        ["login.subtitle"] = new("Quản trị dữ liệu kho", "Warehouse data administration"),
        ["login.username"] = new("Tên đăng nhập", "Username"),
        ["login.password"] = new("Mật khẩu", "Password"),
        ["login.signIn"] = new("Đăng nhập", "Sign in"),
        ["login.signingIn"] = new("Đang đăng nhập...", "Signing in..."),
        ["login.failed"] = new("Đăng nhập thất bại.", "Sign-in failed."),

        // Dashboard
        ["dashboard.title"] = new("Tổng quan", "Dashboard"),
        ["dashboard.products"] = new("Sản phẩm", "Products"),
        ["dashboard.locations"] = new("Vị trí kho", "Locations"),
        ["dashboard.totalQty"] = new("Tổng số lượng tồn", "Total on-hand qty"),
        ["dashboard.lowStockCount"] = new("Cảnh báo tồn thấp", "Low-stock items"),
        ["dashboard.belowMin"] = new("Sản phẩm dưới định mức", "Products below minimum"),
        ["dashboard.noLowStock"] = new("Không có sản phẩm nào dưới định mức. 🎉", "No products below minimum. 🎉"),

        // Products
        ["products.title"] = new("Sản phẩm", "Products"),
        ["products.add"] = new("Thêm sản phẩm", "Add product"),
        ["products.edit"] = new("Sửa sản phẩm", "Edit product"),
        ["products.code"] = new("Mã sản phẩm", "Product code"),
        ["products.codeShort"] = new("Mã SP", "Code"),
        ["products.name"] = new("Tên sản phẩm", "Product name"),
        ["products.description"] = new("Mô tả", "Description"),
        ["products.unit"] = new("Đơn vị tính", "Unit"),
        ["products.unitShort"] = new("Đơn vị", "Unit"),
        ["products.minQty"] = new("Định mức tối thiểu", "Min quantity"),
        ["products.maxQty"] = new("Định mức tối đa", "Max quantity"),
        ["products.minShort"] = new("Định mức min", "Min"),
        ["products.maxShort"] = new("Định mức max", "Max"),
        ["products.none"] = new("Chưa có sản phẩm nào.", "No products yet."),
        ["products.confirmDelete"] = new("Xóa sản phẩm này? (Sản phẩm sẽ được ngừng hoạt động)", "Delete this product? (It will be deactivated.)"),

        // Locations
        ["locations.title"] = new("Vị trí kho", "Locations"),
        ["locations.add"] = new("Thêm vị trí", "Add location"),
        ["locations.edit"] = new("Sửa vị trí", "Edit location"),
        ["locations.code"] = new("Mã vị trí", "Location code"),
        ["locations.name"] = new("Tên vị trí", "Location name"),
        ["locations.none"] = new("Chưa có vị trí nào.", "No locations yet."),
        ["locations.confirmDelete"] = new("Xóa vị trí này?", "Delete this location?"),

        // Stocks
        ["stocks.title"] = new("Tồn kho", "Stock on hand"),
        ["stocks.searchHint"] = new("Tìm theo sản phẩm / vị trí / QR...", "Search product / location / QR..."),
        ["stocks.qrCode"] = new("Mã QR", "QR code"),
        ["stocks.lastUpdated"] = new("Cập nhật lần cuối", "Last updated"),
        ["stocks.none"] = new("Chưa có dữ liệu tồn kho.", "No stock data yet."),

        // Movements
        ["stockIns.title"] = new("Lịch sử nhập kho", "Stock-in history"),
        ["stockOuts.title"] = new("Lịch sử xuất kho", "Stock-out history"),
        ["movements.code"] = new("Mã phiếu", "Voucher code"),
        ["movements.searchHint"] = new("Tìm sản phẩm / mã / vị trí...", "Search product / code / location..."),
        ["stockIns.none"] = new("Không có phiếu nhập nào.", "No stock-in records."),
        ["stockOuts.none"] = new("Không có phiếu xuất nào.", "No stock-out records."),

        // Transfers
        ["transfers.title"] = new("Điều chuyển kho", "Stock transfers"),
        ["transfers.create"] = new("Tạo điều chuyển", "New transfer"),
        ["transfers.searchHint"] = new("Tìm sản phẩm / vị trí...", "Search product / location..."),
        ["transfers.from"] = new("Từ vị trí", "From location"),
        ["transfers.to"] = new("Đến vị trí", "To location"),
        ["transfers.source"] = new("Tồn kho nguồn", "Source stock"),
        ["transfers.dest"] = new("Vị trí đích", "Destination location"),
        ["transfers.max"] = new("Tối đa", "Max"),
        ["transfers.submit"] = new("Điều chuyển", "Transfer"),
        ["transfers.submitting"] = new("Đang chuyển...", "Transferring..."),
        ["transfers.none"] = new("Chưa có phiếu điều chuyển nào.", "No transfers yet."),
        ["transfers.onHand"] = new("tồn", "on hand"),

        // Delivery orders
        ["delivery.title"] = new("Đơn giao hàng", "Delivery orders"),
        ["delivery.searchHint"] = new("Tìm PO / sản phẩm...", "Search PO / product..."),
        ["delivery.poNumber"] = new("Số PO", "PO number"),
        ["delivery.deliveryDate"] = new("Ngày giao", "Delivery date"),
        ["delivery.none"] = new("Chưa có đơn giao hàng nào.", "No delivery orders yet."),

        // Low stock
        ["lowStock.title"] = new("Cảnh báo tồn thấp", "Low-stock alerts"),
        ["lowStock.subtitle"] = new("Danh sách sản phẩm có tổng tồn kho dưới định mức tối thiểu.", "Products whose total on-hand quantity is below the reorder level."),
        ["lowStock.current"] = new("Tồn hiện tại", "Current qty"),
        ["lowStock.min"] = new("Định mức tối thiểu", "Min quantity"),
        ["lowStock.shortage"] = new("Thiếu hụt", "Shortage"),

        // Reports
        ["reports.title"] = new("Báo cáo biến động tồn kho", "Stock movement report"),
        ["reports.view"] = new("Xem báo cáo", "Run report"),
        ["reports.totalIn"] = new("Tổng nhập", "Total in"),
        ["reports.totalOut"] = new("Tổng xuất", "Total out"),
        ["reports.currentStock"] = new("Tồn hiện tại", "Current stock"),
        ["reports.byProduct"] = new("Nhập / Xuất theo sản phẩm", "In / Out by product"),
        ["reports.in"] = new("Nhập", "In"),
        ["reports.out"] = new("Xuất", "Out"),
        ["reports.none"] = new("Không có biến động trong khoảng thời gian này.", "No movement in the selected period."),

        // Users
        ["users.title"] = new("Người dùng", "Users"),
        ["users.add"] = new("Thêm người dùng", "Add user"),
        ["users.edit"] = new("Sửa người dùng", "Edit user"),
        ["users.username"] = new("Tên đăng nhập", "Username"),
        ["users.password"] = new("Mật khẩu", "Password"),
        ["users.fullName"] = new("Họ tên", "Full name"),
        ["users.role"] = new("Vai trò", "Role"),
        ["users.lastLogin"] = new("Đăng nhập lần cuối", "Last login"),
        ["users.none"] = new("Chưa có người dùng nào.", "No users yet."),
        ["users.confirmDelete"] = new("Vô hiệu hóa người dùng này?", "Deactivate this user?"),
    };
}
