namespace NKKhoan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietCongViec",
                c => new
                    {
                        MaNKSLK = c.Int(nullable: false),
                        MaCongViec = c.Int(nullable: false),
                        SanLuongThucTe = c.Int(),
                        SoLoSanPham = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => new { t.MaNKSLK, t.MaCongViec })
                .ForeignKey("dbo.CongViec", t => t.MaCongViec)
                .ForeignKey("dbo.NKSLK", t => t.MaNKSLK, cascadeDelete: true)
                .Index(t => t.MaNKSLK)
                .Index(t => t.MaCongViec);
            
            CreateTable(
                "dbo.CongViec",
                c => new
                    {
                        MaCongViec = c.Int(nullable: false, identity: true),
                        TenCongViec = c.String(maxLength: 50),
                        DinhMucKhoan = c.Decimal(precision: 18, scale: 2),
                        DonViKhoan = c.String(maxLength: 50),
                        HeSoKhoan = c.Int(),
                        DinhMucLaoDong = c.Int(),
                        DonGia = c.Int(),
                        SanPham_MaSanPham = c.Int(),
                    })
                .PrimaryKey(t => t.MaCongViec)
                .ForeignKey("dbo.SanPham", t => t.SanPham_MaSanPham)
                .Index(t => t.SanPham_MaSanPham);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSanPham = c.Int(nullable: false, identity: true),
                        TenSanPham = c.String(nullable: false, maxLength: 50),
                        SoDangKy = c.String(nullable: false, maxLength: 50),
                        HanSuDung = c.Int(nullable: false),
                        QuyCach = c.String(nullable: false, maxLength: 50),
                        NgayDangKy = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.MaSanPham);
            
            CreateTable(
                "dbo.NKSLK",
                c => new
                    {
                        MaNKSLK = c.Int(nullable: false, identity: true),
                        NgayThucHienKhoan = c.DateTime(nullable: false, storeType: "date"),
                        GioBatDau = c.Time(precision: 7),
                        GioKetThuc = c.Time(precision: 7),
                    })
                .PrimaryKey(t => t.MaNKSLK);
            
            CreateTable(
                "dbo.ChiTietNhanCongKhoan",
                c => new
                    {
                        MaNKSLK = c.Int(nullable: false),
                        MaNhanCong = c.Int(nullable: false),
                        NgayThucHienKhoan = c.DateTime(storeType: "date"),
                        GioBatDau = c.Time(precision: 7),
                        GioKetThuc = c.Time(precision: 7),
                    })
                .PrimaryKey(t => new { t.MaNKSLK, t.MaNhanCong })
                .ForeignKey("dbo.CongNhan", t => t.MaNhanCong)
                .ForeignKey("dbo.NKSLK", t => t.MaNKSLK, cascadeDelete: true)
                .Index(t => t.MaNKSLK)
                .Index(t => t.MaNhanCong);
            
            CreateTable(
                "dbo.CongNhan",
                c => new
                    {
                        MaNhanCong = c.Int(nullable: false, identity: true),
                        HoTen = c.String(nullable: false, maxLength: 50),
                        NgayNamSinh = c.DateTime(nullable: false, storeType: "date"),
                        QueQuan = c.String(nullable: false, maxLength: 50),
                        GioiTinh = c.String(maxLength: 50),
                        MatKhau = c.String(maxLength: 100),
                        LuongHopDong = c.Int(nullable: false),
                        LuongBaoHiem = c.Int(nullable: false),
                        MaPhongBan = c.Int(nullable: false),
                        MaChucVu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaNhanCong)
                .ForeignKey("dbo.ChucVus", t => t.MaChucVu, cascadeDelete: true)
                .ForeignKey("dbo.PhongBans", t => t.MaPhongBan, cascadeDelete: true)
                .Index(t => t.MaPhongBan)
                .Index(t => t.MaChucVu);
            
            CreateTable(
                "dbo.ChucVus",
                c => new
                    {
                        MaChucVu = c.Int(nullable: false, identity: true),
                        TenChucVu = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MaChucVu);
            
            CreateTable(
                "dbo.PhongBans",
                c => new
                    {
                        MaPhongBan = c.Int(nullable: false, identity: true),
                        TenPhongBan = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MaPhongBan);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ChiTietNhanCongKhoan", "MaNKSLK", "dbo.NKSLK");
            DropForeignKey("dbo.CongNhan", "MaPhongBan", "dbo.PhongBans");
            DropForeignKey("dbo.CongNhan", "MaChucVu", "dbo.ChucVus");
            DropForeignKey("dbo.ChiTietNhanCongKhoan", "MaNhanCong", "dbo.CongNhan");
            DropForeignKey("dbo.ChiTietCongViec", "MaNKSLK", "dbo.NKSLK");
            DropForeignKey("dbo.CongViec", "SanPham_MaSanPham", "dbo.SanPham");
            DropForeignKey("dbo.ChiTietCongViec", "MaCongViec", "dbo.CongViec");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CongNhan", new[] { "MaChucVu" });
            DropIndex("dbo.CongNhan", new[] { "MaPhongBan" });
            DropIndex("dbo.ChiTietNhanCongKhoan", new[] { "MaNhanCong" });
            DropIndex("dbo.ChiTietNhanCongKhoan", new[] { "MaNKSLK" });
            DropIndex("dbo.CongViec", new[] { "SanPham_MaSanPham" });
            DropIndex("dbo.ChiTietCongViec", new[] { "MaCongViec" });
            DropIndex("dbo.ChiTietCongViec", new[] { "MaNKSLK" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PhongBans");
            DropTable("dbo.ChucVus");
            DropTable("dbo.CongNhan");
            DropTable("dbo.ChiTietNhanCongKhoan");
            DropTable("dbo.NKSLK");
            DropTable("dbo.SanPham");
            DropTable("dbo.CongViec");
            DropTable("dbo.ChiTietCongViec");
        }
    }
}