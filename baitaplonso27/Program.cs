using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
class Program
{
    static int chon, n;
    struct nhanvien
    {
        public string Hoten, quequan, Manv, Namsinh, CMT;
    }
    struct quanlyhd
    {
        public string Hoten, diachi, Maql, CMT, sdt;
    }
    struct bangcap
    {
        public string tenbangcap, Maql;
    }
    struct hopdong
    {
        public string Mahd, Manv, Maql, ngaybatdau, ngayketthuc, ngayky, luongcb;
    }
    static nhanvien[] nv;
    static quanlyhd[] qlhd;
    static bangcap[] bc;
    static hopdong[] hd;
    #region hàm nhập thông tin nhân viên
    static void nhapnhanvien(ref nhanvien[] nv)
    {
        Console.Clear();
        Console.SetCursorPosition(1, 2);
        Console.WriteLine("Mã nhân viên \t Họ Tên \t Năm sinh \t Quê Quán \t Chứng Minh Thư ");
        for (int i = 0; i < nv.Length; i++)
        {
            // bắt lỗi nhập mã nhân viên ,nếu nhập bất kì gì khác số nguyên sẽ bắt nhập lại
            while (true)
            {
            batloimanv:
                Console.SetCursorPosition(1, 3 + i);
                nv[i].Manv = Console.ReadLine();
                int b;
                bool c = int.TryParse(nv[i].Manv, out b);
                if (c == false)
                {
                    Console.SetCursorPosition(1, 3 + i);
                    for (int j = 0; j < nv[i].Manv.Length; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloimanv;
                }
                else if (i > 0)
                {
                    int dem = 0;
                    for (int j = 0; j < i; j++)
                    {
                        if (int.Parse(nv[i].Manv) == int.Parse(nv[j].Manv))
                        {
                            dem += 1;
                        }
                    }
                    if (dem == 1)
                    {
                        Console.SetCursorPosition(1, 3 + i);
                        for (int j = 0; j < nv[i].Manv.Length; j++)
                        {
                            Console.Write(" ");
                        }
                        goto batloimanv;
                    }
                }
                break;
            }
            // bắt lỗi nhập chuỗi ,nếu để trống sẽ bắt nhập lại
            while (true)
            {
            batloihoten:
                try
                {
                    while (true)
                    {
                        Console.SetCursorPosition(17, 3 + i);
                        nv[i].Hoten = Console.ReadLine();
                        if (nv[i].Hoten != "")
                            break;
                    }
                }
                catch
                {
                    Console.SetCursorPosition(17, 3 + i);
                    int b = nv[i].Hoten.Length;
                    for (int j = 0; j < b; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloihoten;
                }
                break;
            }
            while (true)
            {
            batloinamsinh:
                Console.SetCursorPosition(33, 3 + i);
                nv[i].Namsinh = Console.ReadLine();
                int b;
                bool c = int.TryParse(nv[i].Namsinh, out b);
                if (c == false)
                {
                    Console.SetCursorPosition(33, 3 + i);
                    for (int j = 0; j < nv[i].Namsinh.Length; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloinamsinh;
                }
                break;
            }
            while (true)
            {
            batloiquequan:
                try
                {
                    while (true)
                    {
                        Console.SetCursorPosition(49, 3 + i);
                        nv[i].quequan = Console.ReadLine();
                        if (nv[i].quequan != "")
                            break;
                    }
                }
                catch
                {
                    Console.SetCursorPosition(49, 3 + i);
                    int b = nv[i].quequan.Length;
                    for (int j = 0; j < b; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloiquequan;
                }
                break;
            }
            while (true)
            {
            batloicmt:
                Console.SetCursorPosition(65, 3 + i);
                nv[i].CMT = Console.ReadLine();
                int b;
                bool c = int.TryParse(nv[i].CMT, out b);
                if (c == false)
                {
                    Console.SetCursorPosition(65, 3 + i);
                    for (int j = 0; j < nv[i].CMT.Length; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloicmt;
                }
                break;
            }
            Console.WriteLine();
        }
    }
    #endregion
    #region hàm nhập thông tin quản lý hợp đồng
    static void nhapquanly(ref quanlyhd[] qlhd)
    {
        Console.Clear();
        Console.SetCursorPosition(1, 2);
        Console.WriteLine("Mã quản lý \t Họ Tên quản lý \t địa chỉ \t Chứng Minh Thư \t số điện thoại ");
        for (int i = 0; i < qlhd.Length; i++)
        {
            // bắt lỗi nhập số nguyên  ,nếu nhập bất kì gì khác số nguyên sẽ bắt nhập lại
            while (true)
            {
            batloimaquanly:
                Console.SetCursorPosition(1, 3 + i);
                qlhd[i].Maql = Console.ReadLine();
                int b;
                bool c = int.TryParse(qlhd[i].Maql, out b);
                if (c == false)
                {
                    Console.SetCursorPosition(1, 3 + i);
                    for (int j = 0; j < qlhd[i].Maql.Length; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloimaquanly;
                }
                else if (i > 0)
                {
                    int dem = 0;
                    for (int j = 0; j < i; j++)
                    {
                        if (int.Parse(qlhd[i].Maql) == int.Parse(qlhd[j].Maql))
                        {
                            dem += 1;
                        }
                    }
                    if (dem == 1)
                    {
                        Console.SetCursorPosition(1, 3 + i);
                        for (int j = 0; j < qlhd[i].Maql.Length; j++)
                        {
                            Console.Write(" ");
                        }
                        goto batloimaquanly;
                    }
                }
                break;
            }
            // bắt lỗi nhập chuỗi ,nếu để trống sẽ bắt nhập lại
            while (true)
            {
            batloihoten:
                try
                {
                    while (true)
                    {
                        Console.SetCursorPosition(17, 3 + i);
                        qlhd[i].Hoten = Console.ReadLine();
                        if (qlhd[i].Hoten != "")
                            break;
                    }
                }
                catch
                {
                    Console.SetCursorPosition(17, 3 + i);
                    int b = qlhd[i].Hoten.Length;
                    for (int j = 0; j < b; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloihoten;
                }
                break;
            }
            while (true)
            {
            batloidiachi:
                try
                {
                    while (true)
                    {
                        Console.SetCursorPosition(41, 3 + i);
                        qlhd[i].diachi = Console.ReadLine();
                        if (qlhd[i].diachi != "")
                            break;
                    }
                }
                catch
                {
                    Console.SetCursorPosition(41, 3 + i);
                    int b = qlhd[i].diachi.Length;
                    for (int j = 0; j < b; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloidiachi;
                }
                break;
            }
            while (true)
            {
            batloicmt:
                Console.SetCursorPosition(57, 3 + i);
                qlhd[i].CMT = Console.ReadLine();
                int b;
                bool c = int.TryParse(qlhd[i].CMT, out b);
                if (c == false)
                {
                    Console.SetCursorPosition(57, 3 + i);
                    for (int j = 0; j < qlhd[i].CMT.Length; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloicmt;
                }
                break;
            }
            // số điẹn thoại phải là số nguyên và ít nhất 9 chữ số
            while (true)
            {
            batloisdt:
                Console.SetCursorPosition(81, 3 + i);
                qlhd[i].sdt = Console.ReadLine();
                int b;
                bool c = int.TryParse(qlhd[i].sdt, out b);
                if (c == false || qlhd[i].sdt.Length < 9)
                {
                    Console.SetCursorPosition(81, 3 + i);
                    for (int j = 0; j < qlhd[i].sdt.Length; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloisdt;
                }
                break;
            }
            Console.WriteLine();
        }
    }
    #endregion
    #region hàm nhập thông tin bằng cấp
    static void nhapbangcap(ref bangcap[] bc, quanlyhd[] qlhd)
    {
        Console.Clear();
        Console.SetCursorPosition(1, 2);
        Console.WriteLine("Mã quản lý \t bằng cấp");
        for (int i = 0; i < qlhd.Length; i++)
        {
            // vì mã quản lý tham chiếu từ quản lý hợp đồng lên sẽ lấy sẵn lần lượt mã quản lý trong bảng quản lý hd
            Console.SetCursorPosition(1, 3 + i);
            bc[i].Maql = qlhd[i].Maql;
            Console.WriteLine(bc[i].Maql);
            // bắt lỗi nhập chuỗi ,nếu để trống sẽ bắt nhập lại
            while (true)
            {
            batloibangcap:
                try
                {
                    while (true)
                    {
                        Console.SetCursorPosition(19, 3 + i);
                        bc[i].tenbangcap = Console.ReadLine();
                        if (qlhd[i].Hoten != "")
                            break;
                    }
                }
                catch
                {
                    Console.SetCursorPosition(19, 3 + i);
                    int b = bc[i].tenbangcap.Length;
                    for (int j = 0; j < b; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloibangcap;
                }
                break;
            }
            Console.WriteLine();
        }
    }
    #endregion
    #region hàm nhập hợp đồng
    static void nhaphopdong(ref hopdong[] hd, nhanvien[] nv, quanlyhd[] qlhd)
    {
        Console.Clear();
        Console.SetCursorPosition(1, 2);
        Console.WriteLine("Mã hợp đồng \t Mã quản lý \t Mã nhân viên \t Ngày bắt đầu  \t Ngày kết thúc \t Ngày ký \t Lương cơ bản");
        for (int i = 0; i < hd.Length; i++)
        {
            // bắt lỗi nhập số nguyên  ,nếu nhập bất kì gì khác số nguyên sẽ bắt nhập lại
            while (true)
            {
            batloimahopdong:
                Console.SetCursorPosition(1, 3 + i);
                hd[i].Mahd = Console.ReadLine();
                int b;
                bool c = int.TryParse(hd[i].Mahd, out b);
                if (c == false)
                {
                    Console.SetCursorPosition(1, 3 + i);
                    for (int j = 0; j < hd[i].Mahd.Length; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloimahopdong;
                }
                break;
            }
            // bắt lỗi nhập mã quản lý ,1 là phải nhập số nguyên ,2 là phải tồn tại trong quản lý hợp đồng
            while (true)
            {
            batloimaql:
                Console.SetCursorPosition(20, 3 + i);
                hd[i].Maql = Console.ReadLine(); ;
                int b;
                bool c = int.TryParse(hd[i].Maql, out b);
                if (c == false)
                {
                    Console.SetCursorPosition(20, 3 + i);
                    for (int j = 0; j < hd[i].Maql.Length; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloimaql;
                }
                else if (c == true)
                {
                    int dem = 0;
                    for (int k = 0; k < qlhd.Length; k++)
                    {
                        if (hd[i].Maql == qlhd[k].Maql)
                        {
                            dem += 1;
                        }
                    }
                    if (dem == 0)
                    {
                        Console.SetCursorPosition(20, 3 + i);
                        for (int j = 0; j < hd[i].Maql.Length; j++)
                        {
                            Console.Write(" ");
                        }
                        goto batloimaql;
                    }
                }
                break;
            }
            while (true)
            {
            batloimanv:
                Console.SetCursorPosition(39, 3 + i);
                hd[i].Manv = Console.ReadLine(); ;
                int b;
                bool c = int.TryParse(hd[i].Manv, out b);
                if (c == false)
                {
                    Console.SetCursorPosition(39, 3 + i);
                    for (int j = 0; j < hd[i].Manv.Length; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloimanv;
                }
                else if (c == true)
                {
                    int dem = 0;
                    for (int k = 0; k < qlhd.Length; k++)
                    {
                        if (hd[i].Maql == nv[k].Manv)
                        {
                            dem += 1;
                        }
                    }
                    if (dem == 0)
                    {
                        Console.SetCursorPosition(39, 3 + i);
                        for (int j = 0; j < hd[i].Maql.Length; j++)
                        {
                            Console.Write(" ");
                        }
                        goto batloimanv;
                    }
                }
                break;
            }
            // nhập ngày /tháng / năm, vd 25/2/2000
            while (true)
            {
            batloingaybd:
                Console.SetCursorPosition(59, 3 + i);
                hd[i].ngaybatdau = Console.ReadLine();
                string ghep = "";

                string[] a = hd[i].ngaybatdau.Split('/');
                for (int h = 0; h < a.Length; h++)
                {
                    ghep += a[h];
                }
                int b;
                bool c = int.TryParse(ghep, out b);
                if (c == false || a.Length != 3)
                {
                    Console.SetCursorPosition(59, 3 + i);
                    for (int j = 0; j < hd[i].ngaybatdau.Length; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloingaybd;
                    ;
                }
                else if (c == true)
                {
                    if (int.Parse(a[2]) < 0)
                    {
                        Console.SetCursorPosition(59, 3 + i);
                        for (int j = 0; j < hd[i].ngaybatdau.Length; j++)
                        {
                            Console.Write(" ");
                        }
                        goto batloingaybd;
                    }
                    // kiểm tra năm nhuận và tháng 2
                    if (int.Parse(a[2]) % 4 == 0)
                    {
                        // nếu nhập tháng 2 hơn 29 ngày sẽ nhập lại
                        if (int.Parse(a[0]) > 29 && int.Parse(a[1]) == 2)
                        {
                            Console.SetCursorPosition(59, 3 + i);
                            for (int j = 0; j < hd[i].ngaybatdau.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloingaybd;
                            ;
                        }
                    }
                    // không phải năm nhuận thì tháng 2 có 28 ngày tối đa, tháng 1,3,5,7,8,10,12 có tối đa 31 ngày
                    //tháng 2,4,6,9,11 có tối đa 30 ngày
                    if (int.Parse(a[2]) % 4 != 0)
                    {
                        if (int.Parse(a[1]) == 2)
                        {
                            if (int.Parse(a[0]) > 28 || int.Parse(a[0]) < 0)
                            {
                                Console.SetCursorPosition(59, 3 + i);
                                for (int j = 0; j < hd[i].ngaybatdau.Length; j++)
                                {
                                    Console.Write(" ");
                                }
                                goto batloingaybd;
                            }
                        }
                        else if (int.Parse(a[1]) == 1 || int.Parse(a[1]) == 3 || int.Parse(a[1]) == 5 || int.Parse(a[1]) == 7 || int.Parse(a[1]) == 8 || int.Parse(a[1]) == 10 || int.Parse(a[1]) == 12)
                        {
                            if (int.Parse(a[0]) > 31 || int.Parse(a[0]) < 0)
                            {
                                Console.SetCursorPosition(59, 3 + i);
                                for (int j = 0; j < hd[i].ngaybatdau.Length; j++)
                                {
                                    Console.Write(" ");
                                }
                                goto batloingaybd;
                            }
                        }
                        else
                        {
                            if (int.Parse(a[0]) > 30 || int.Parse(a[0]) < 0)
                            {
                                Console.SetCursorPosition(59, 3 + i);
                                for (int j = 0; j < hd[i].ngaybatdau.Length; j++)
                                {
                                    Console.Write(" ");
                                }
                                goto batloingaybd;
                            }
                        }
                    }
                }
                break;
            }
            while (true)
            {
            batloingaykt:
                Console.SetCursorPosition(79, 3 + i);
                hd[i].ngayketthuc = Console.ReadLine();
                string ghep = "";

                string[] a = hd[i].ngayketthuc.Split('/');
                for (int h = 0; h < a.Length; h++)
                {
                    ghep += a[h];
                }
                int b;
                bool c = int.TryParse(ghep, out b);
                if (c == false || a.Length != 3)
                {
                    Console.SetCursorPosition(79, 3 + i);
                    for (int j = 0; j < hd[i].ngayketthuc.Length; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloingaykt;
                }
                else if (c == true)
                {
                    if (int.Parse(a[2]) < 0)
                    {
                        Console.SetCursorPosition(79, 3 + i);
                        for (int j = 0; j < hd[i].ngayketthuc.Length; j++)
                        {
                            Console.Write(" ");
                        }
                        goto batloingaykt;
                    }
                    // kiểm tra năm nhuận và tháng 2
                    if (int.Parse(a[2]) % 4 == 0)
                    {
                        // nếu nhập tháng 2 hơn 29 ngày sẽ nhập lại
                        if (int.Parse(a[0]) > 29 && int.Parse(a[1]) == 2)
                        {
                            Console.SetCursorPosition(79, 3 + i);
                            for (int j = 0; j < hd[i].ngayketthuc.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloingaykt;
                        }
                    }
                    // không phải năm nhuận thì tháng 2 có 28 ngày tối đa, tháng 1,3,5,7,8,10,12 có tối đa 31 ngày
                    //tháng 2,4,6,9,11 có tối đa 30 ngày
                    if (int.Parse(a[2]) % 4 != 0)
                    {
                        if (int.Parse(a[1]) == 2)
                        {
                            if (int.Parse(a[0]) > 28 || int.Parse(a[0]) < 0)
                            {
                                Console.SetCursorPosition(79, 3 + i);
                                for (int j = 0; j < hd[i].ngayketthuc.Length; j++)
                                {
                                    Console.Write(" ");
                                }
                                goto batloingaykt;
                            }
                        }
                        else if (int.Parse(a[1]) == 1 || int.Parse(a[1]) == 3 || int.Parse(a[1]) == 5 || int.Parse(a[1]) == 7 || int.Parse(a[1]) == 8 || int.Parse(a[1]) == 10 || int.Parse(a[1]) == 12)
                        {
                            if (int.Parse(a[0]) > 31 || int.Parse(a[0]) < 0)
                            {
                                Console.SetCursorPosition(79, 3 + i);
                                for (int j = 0; j < hd[i].ngayketthuc.Length; j++)
                                {
                                    Console.Write(" ");
                                }
                                goto batloingaykt;
                            }
                        }
                        else
                        {
                            if (int.Parse(a[0]) > 30 || int.Parse(a[0]) < 0)
                            {
                                Console.SetCursorPosition(79, 3 + i);
                                for (int j = 0; j < hd[i].ngayketthuc.Length; j++)
                                {
                                    Console.Write(" ");
                                }
                                goto batloingaykt;
                            }
                        }
                    }
                }

                break;
            }
            while (true)
            {
            batloingayky:
                Console.SetCursorPosition(99, 3 + i);
                hd[i].ngayky = Console.ReadLine();
                string ghep = "";

                string[] a = hd[i].ngayky.Split('/');
                for (int h = 0; h < a.Length; h++)
                {
                    ghep += a[h];
                }
                int b;
                bool c = int.TryParse(ghep, out b);
                if (c == false || a.Length != 3)
                {
                    Console.SetCursorPosition(99, 3 + i);
                    for (int j = 0; j < hd[i].ngayky.Length; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloingayky;
                }
                else if (c == true)
                {
                    if (int.Parse(a[2]) < 0)
                    {
                        Console.SetCursorPosition(99, 3 + i);
                        for (int j = 0; j < hd[i].ngayky.Length; j++)
                        {
                            Console.Write(" ");
                        }
                        goto batloingayky;
                    }
                    // kiểm tra năm nhuận và tháng 2
                    if (int.Parse(a[2]) % 4 == 0)
                    {
                        // nếu nhập tháng 2 hơn 29 ngày sẽ nhập lại
                        if (int.Parse(a[0]) > 29 && int.Parse(a[1]) == 2)
                        {
                            Console.SetCursorPosition(99, 3 + i);
                            for (int j = 0; j < hd[i].ngayky.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloingayky;
                        }
                    }
                    // không phải năm nhuận thì tháng 2 có 28 ngày tối đa, tháng 1,3,5,7,8,10,12 có tối đa 31 ngày
                    //tháng 2,4,6,9,11 có tối đa 30 ngày
                    if (int.Parse(a[2]) % 4 != 0)
                    {
                        if (int.Parse(a[1]) == 2)
                        {
                            if (int.Parse(a[0]) > 28 || int.Parse(a[0]) < 0)
                            {
                                Console.SetCursorPosition(99, 3 + i);
                                for (int j = 0; j < hd[i].ngayky.Length; j++)
                                {
                                    Console.Write(" ");
                                }
                                goto batloingayky;
                            }
                        }
                        else if (int.Parse(a[1]) == 1 || int.Parse(a[1]) == 3 || int.Parse(a[1]) == 5 || int.Parse(a[1]) == 7 || int.Parse(a[1]) == 8 || int.Parse(a[1]) == 10 || int.Parse(a[1]) == 12)
                        {
                            if (int.Parse(a[0]) > 31 || int.Parse(a[0]) < 0)
                            {
                                Console.SetCursorPosition(99, 3 + i);
                                for (int j = 0; j < hd[i].ngayky.Length; j++)
                                {
                                    Console.Write(" ");
                                }
                                goto batloingayky;
                            }
                        }
                        else
                        {
                            if (int.Parse(a[0]) > 30 || int.Parse(a[0]) < 0)
                            {
                                Console.SetCursorPosition(99, 3 + i);
                                for (int j = 0; j < hd[i].ngayky.Length; j++)
                                {
                                    Console.Write(" ");
                                }
                                goto batloingayky;
                            }
                        }
                    }
                }
                break;
            }
            while (true)
            {
            batloiluongcb:
                Console.SetCursorPosition(115, 3 + i);
                hd[i].luongcb = Console.ReadLine();
                int b;
                bool c = int.TryParse(hd[i].luongcb, out b);
                if (c == false)
                {
                    Console.SetCursorPosition(1, 3 + i);
                    for (int j = 0; j < hd[i].luongcb.Length; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloiluongcb;
                }
                else if (int.Parse(hd[i].luongcb) < 0)
                {
                    Console.SetCursorPosition(115, 3 + i);
                    for (int j = 0; j < hd[i].luongcb.Length; j++)
                    {
                        Console.Write(" ");
                    }
                    goto batloiluongcb;
                }
                break;
            }
            Console.WriteLine();
        }
    }
    #endregion
    #region hàm sửa đổi thông tin
    static void suathongtin(ref nhanvien[] nv, ref quanlyhd[] qlhd, ref bangcap[] bc, ref hopdong[] hd, int a, ref int chon)
    {
        if (a == 1)// sửa đổi thông tin nhân viên
        {
        nhaplaimanv:
            Console.Write("nhập mã nhân viên muốn chỉnh sửa :");
            int nhap = int.Parse(Console.ReadLine());
            Console.Clear();
            int nhapma = 0;
            for (int i = 0; i < nv.Length; i++)
            {
                if (nhap == int.Parse(nv[i].Manv))
                {
                    while (true)
                    {
                    batloimanv:
                        Console.SetCursorPosition(1, 3 + i);
                        nv[i].Manv = Console.ReadLine();
                        int b;
                        bool c = int.TryParse(nv[i].Manv, out b);
                        if (c == false)
                        {
                            Console.SetCursorPosition(1, 3 + i);
                            for (int j = 0; j < nv[i].Manv.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloimanv;
                        }
                        else if (i > 0)
                        {
                            int dem = 0;
                            for (int j = 0; j < i; j++)
                            {
                                if (int.Parse(nv[i].Manv) == int.Parse(nv[j].Manv))
                                {
                                    dem += 1;
                                }
                            }
                            if (dem == 1)
                            {
                                Console.SetCursorPosition(1, 3 + i);
                                for (int j = 0; j < nv[i].Manv.Length; j++)
                                {
                                    Console.Write(" ");
                                }
                                goto batloimanv;
                            }
                        }
                        break;
                    }
                    for (int p = 0; p < hd.Length; p++)
                    {
                        if (int.Parse(hd[p].Manv) == nhap)
                        {
                            hd[p].Manv = nv[i].Manv;
                        }
                    }
                    // bắt lỗi nhập chuỗi ,nếu để trống sẽ bắt nhập lại
                    while (true)
                    {
                    batloihoten:
                        try
                        {
                            while (true)
                            {
                                Console.SetCursorPosition(21, 3 + i);
                                nv[i].Hoten = Console.ReadLine();
                                if (nv[i].Hoten != "")
                                    break;
                            }
                        }
                        catch
                        {
                            Console.SetCursorPosition(21, 3 + i);
                            int b = nv[i].Hoten.Length;
                            for (int j = 0; j < b; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloihoten;
                        }
                        break;
                    }
                    while (true)
                    {
                    batloinamsinh:
                        Console.SetCursorPosition(35, 3 + i);
                        nv[i].Namsinh = Console.ReadLine();
                        int b;
                        bool c = int.TryParse(nv[i].Namsinh, out b);
                        if (c == false)
                        {
                            Console.SetCursorPosition(35, 3 + i);
                            for (int j = 0; j < nv[i].Namsinh.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloinamsinh;
                        }
                        break;
                    }
                    while (true)
                    {
                    batloiquequan:
                        try
                        {
                            while (true)
                            {
                                Console.SetCursorPosition(51, 3 + i);
                                nv[i].quequan = Console.ReadLine();
                                if (nv[i].quequan != "")
                                    break;
                            }
                        }
                        catch
                        {
                            Console.SetCursorPosition(51, 3 + i);
                            int b = nv[i].quequan.Length;
                            for (int j = 0; j < b; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloiquequan;
                        }
                        break;
                    }
                    while (true)
                    {
                    batloicmt:
                        Console.SetCursorPosition(67, 3 + i);
                        nv[i].CMT = Console.ReadLine();
                        int b;
                        bool c = int.TryParse(nv[i].CMT, out b);
                        if (c == false)
                        {
                            Console.SetCursorPosition(35, 3 + i);
                            for (int j = 0; j < nv[i].CMT.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloicmt;
                        }
                        break;
                    }
                    nhapma += 1;
                }
            }
            if (nhapma == 0)
            {
                do
                {
                    Console.WriteLine("mã nhân viên bạn nhập không tồn tại ");
                    Console.WriteLine("bạn muốn nhập lại hay thoát ");
                    Console.WriteLine("0. Thoát ");
                    Console.WriteLine("1. Nhập lại ");
                    Console.Write("Mời bạn chọn:");
                    chon = int.Parse(Console.ReadLine());
                }
                while (chon != 0 && chon != 1);
                if (chon == 1)
                {
                    goto nhaplaimanv;
                }
            }
        }
        else if (a == 2)
        {
        nhaplaimaql:
            Console.Write("nhập mã quản lý muốn chỉnh sửa :");
            int nhap = int.Parse(Console.ReadLine());
            Console.Clear();
            int nhapma = 0;
            for (int i = 0; i < qlhd.Length; i++)
            {
                if (int.Parse(qlhd[i].Maql) == nhap)
                {
                    while (true)
                    {
                    batloimaquanly:
                        Console.SetCursorPosition(1, 3 + i);
                        qlhd[i].Maql = Console.ReadLine();
                        int b;
                        bool c = int.TryParse(qlhd[i].Maql, out b);
                        if (c == false)
                        {
                            Console.SetCursorPosition(1, 3 + i);
                            for (int j = 0; j < qlhd[i].Maql.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloimaquanly;
                        }
                        else if (i > 0)
                        {
                            int dem = 0;
                            for (int j = 0; j < i; j++)
                            {
                                if (int.Parse(qlhd[i].Maql) == int.Parse(qlhd[j].Maql))
                                {
                                    dem += 1;
                                }
                            }
                            if (dem == 1)
                            {
                                Console.SetCursorPosition(1, 3 + i);
                                for (int j = 0; j < qlhd[i].Maql.Length; j++)
                                {
                                    Console.Write(" ");
                                }
                                goto batloimaquanly;
                            }
                        }
                        break;
                    }
                    for (int p = 0; p < hd.Length; p++)
                    {
                        if (int.Parse(hd[p].Maql) == nhap)
                        {
                            hd[p].Maql = qlhd[i].Maql;
                        }
                    }
                    for (int q = 0; q < bc.Length; q++)
                    {
                        if (int.Parse(bc[q].Maql) == nhap)
                        {
                            bc[q].Maql = qlhd[i].Maql;
                        }
                    }
                    // bắt lỗi nhập chuỗi ,nếu để trống sẽ bắt nhập lại
                    while (true)
                    {
                    batloihoten:
                        try
                        {
                            while (true)
                            {
                                Console.SetCursorPosition(20, 3 + i);
                                qlhd[i].Hoten = Console.ReadLine();
                                if (qlhd[i].Hoten != "")
                                    break;
                            }
                        }
                        catch
                        {
                            Console.SetCursorPosition(20, 3 + i);
                            int b = qlhd[i].Hoten.Length;
                            for (int j = 0; j < b; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloihoten;
                        }
                        break;
                    }
                    while (true)
                    {
                    batloidiachi:
                        try
                        {
                            while (true)
                            {
                                Console.SetCursorPosition(36, 3 + i);
                                qlhd[i].diachi = Console.ReadLine();
                                if (qlhd[i].diachi != "")
                                    break;
                            }
                        }
                        catch
                        {
                            Console.SetCursorPosition(36, 3 + i);
                            int b = qlhd[i].diachi.Length;
                            for (int j = 0; j < b; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloidiachi;
                        }
                        break;
                    }
                    // số chứng minh thư ít nhất 12 số ,phải nhập số nguyên
                    while (true)
                    {
                    batloicmt:
                        Console.SetCursorPosition(44, 3 + i);
                        qlhd[i].CMT = Console.ReadLine();
                        int b;
                        bool c = int.TryParse(qlhd[i].CMT, out b);
                        if (c == false || qlhd[i].CMT.Length < 12)
                        {
                            Console.SetCursorPosition(44, 3 + i);
                            for (int j = 0; j < qlhd[i].CMT.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloicmt;
                        }
                        break;
                    }
                    // số điẹn thoại phải là số nguyên và ít nhất 9 chữ số
                    while (true)
                    {
                    batloisdt:
                        Console.SetCursorPosition(59, 3 + i);
                        qlhd[i].sdt = Console.ReadLine();
                        int b;
                        bool c = int.TryParse(qlhd[i].sdt, out b);
                        if (c == false || qlhd[i].sdt.Length < 9)
                        {
                            Console.SetCursorPosition(59, 3 + i);
                            for (int j = 0; j < qlhd[i].sdt.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloisdt;
                        }
                        break;
                    }
                    nhapma += 1;
                }
            }
            if (nhapma == 0)
            {
                do
                {
                    Console.WriteLine("Mã quản lý bạn nhập không tồn tại ");
                    Console.WriteLine("bạn muốn nhập lại hay thoát ");
                    Console.WriteLine("0. Thoát ");
                    Console.WriteLine("1. Nhập lại ");
                    Console.Write("Mời bạn chọn:");
                    chon = int.Parse(Console.ReadLine());
                }
                while (chon != 0 && chon != 1);
                if (chon == 1)
                {
                    goto nhaplaimaql;
                }
            }
        }
        else if (a == 3)
        {
        nhaplaimaql:
            Console.Write("nhập mã quản lý muốn chỉnh sửa :");
            int nhap = int.Parse(Console.ReadLine());
            Console.Clear();
            int nhapma = 0;
            for (int i = 0; i < qlhd.Length; i++)
            {
                if (int.Parse(bc[i].Maql) == nhap)
                {
                    while (true)
                    {
                    batloibangcap:
                        try
                        {
                            while (true)
                            {
                                Console.SetCursorPosition(19, 3 + i);
                                bc[i].tenbangcap = Console.ReadLine();
                                if (qlhd[i].Hoten != "")
                                    break;
                            }
                        }
                        catch
                        {
                            Console.SetCursorPosition(19, 3 + i);
                            int b = bc[i].tenbangcap.Length;
                            for (int j = 0; j < b; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloibangcap;
                        }
                        break;
                    }
                    nhapma += 1;
                }
            }
            if (nhapma == 0)
            {
                do
                {
                    Console.WriteLine("Mã quản lý bạn nhập không tồn tại ");
                    Console.WriteLine("bạn muốn nhập lại hay thoát ");
                    Console.WriteLine("0. Thoát ");
                    Console.WriteLine("1. Nhập lại ");
                    Console.Write("Mời bạn chọn:");
                    chon = int.Parse(Console.ReadLine());
                }
                while (chon != 0 && chon != 1);
                if (chon == 1)
                {
                    goto nhaplaimaql;
                }
            }
        }
        else
        {
        nhaplaimahd:
            Console.Write("nhập mã hợp đồng muốn chỉnh sửa :");
            int nhap = int.Parse(Console.ReadLine());
            Console.Clear();
            int nhapma = 0;
            for (int i = 0; i < hd.Length; i++)
            {
                if (nhap == int.Parse(hd[i].Mahd))
                {
                    while (true)
                    {
                    batloimahopdong:
                        Console.SetCursorPosition(1, 3 + i);
                        hd[i].Mahd = Console.ReadLine();
                        int b;
                        bool c = int.TryParse(hd[i].Mahd, out b);
                        if (c == false)
                        {
                            Console.SetCursorPosition(1, 3 + i);
                            for (int j = 0; j < hd[i].Mahd.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloimahopdong;
                        }
                        break;
                    }
                    // bắt lỗi nhập mã quản lý ,1 là phải nhập số nguyên ,2 là phải tồn tại trong quản lý hợp đồng
                    while (true)
                    {
                    batloimaql:
                        Console.SetCursorPosition(20, 3 + i);
                        hd[i].Maql = Console.ReadLine(); ;
                        int b;
                        bool c = int.TryParse(hd[i].Maql, out b);
                        if (c == false)
                        {
                            Console.SetCursorPosition(20, 3 + i);
                            for (int j = 0; j < hd[i].Maql.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloimaql;
                        }
                        else if (c == true)
                        {
                            int dem = 0;
                            for (int k = 0; k < qlhd.Length; k++)
                            {
                                if (hd[i].Maql == qlhd[k].Maql)
                                {
                                    dem += 1;
                                }
                            }
                            if (dem == 0)
                            {
                                Console.SetCursorPosition(20, 3 + i);
                                for (int j = 0; j < hd[i].Maql.Length; j++)
                                {
                                    Console.Write(" ");
                                }
                                goto batloimaql;
                            }
                        }
                        break;
                    }
                    while (true)
                    {
                    batloimanv:
                        Console.SetCursorPosition(39, 3 + i);
                        hd[i].Manv = Console.ReadLine(); ;
                        int b;
                        bool c = int.TryParse(hd[i].Manv, out b);
                        if (c == false)
                        {
                            Console.SetCursorPosition(39, 3 + i);
                            for (int j = 0; j < hd[i].Manv.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloimanv;
                        }
                        else if (c == true)
                        {
                            int dem = 0;
                            for (int k = 0; k < qlhd.Length; k++)
                            {
                                if (hd[i].Maql == nv[k].Manv)
                                {
                                    dem += 1;
                                }
                            }
                            if (dem == 0)
                            {
                                Console.SetCursorPosition(39, 3 + i);
                                for (int j = 0; j < hd[i].Maql.Length; j++)
                                {
                                    Console.Write(" ");
                                }
                                goto batloimanv;
                            }
                        }
                        break;
                    }
                    // nhập ngày /tháng / năm, vd 25/2/2000
                    while (true)
                    {
                    batloingaybd:
                        Console.SetCursorPosition(59, 3 + i);
                        hd[i].ngaybatdau = Console.ReadLine();
                        string ghep = "";

                        string[] tach = hd[i].ngaybatdau.Split('/');
                        for (int h = 0; h < tach.Length; h++)
                        {
                            ghep += tach[h];
                        }
                        int b;
                        bool c = int.TryParse(ghep, out b);
                        if (c == false || tach.Length != 3)
                        {
                            Console.SetCursorPosition(59, 3 + i);
                            for (int j = 0; j < hd[i].ngaybatdau.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloingaybd;
                            ;
                        }
                        else if (c == true)
                        {
                            if (int.Parse(tach[2]) < 0)
                            {
                                Console.SetCursorPosition(59, 3 + i);
                                for (int j = 0; j < hd[i].ngaybatdau.Length; j++)
                                {
                                    Console.Write(" ");
                                }
                                goto batloingaybd;
                            }
                            // kiểm tra năm nhuận và tháng 2
                            if (int.Parse(tach[2]) % 4 == 0)
                            {
                                // nếu nhập tháng 2 hơn 29 ngày sẽ nhập lại
                                if (int.Parse(tach[0]) > 29 && int.Parse(tach[1]) == 2)
                                {
                                    Console.SetCursorPosition(59, 3 + i);
                                    for (int j = 0; j < hd[i].ngaybatdau.Length; j++)
                                    {
                                        Console.Write(" ");
                                    }
                                    goto batloingaybd;
                                    ;
                                }
                            }
                            // không phải năm nhuận thì tháng 2 có 28 ngày tối đa, tháng 1,3,5,7,8,10,12 có tối đa 31 ngày
                            //tháng 2,4,6,9,11 có tối đa 30 ngày
                            if (int.Parse(tach[2]) % 4 != 0)
                            {
                                if (int.Parse(tach[1]) == 2)
                                {
                                    if (int.Parse(tach[0]) > 28 || int.Parse(tach[0]) < 0)
                                    {
                                        Console.SetCursorPosition(59, 3 + i);
                                        for (int j = 0; j < hd[i].ngaybatdau.Length; j++)
                                        {
                                            Console.Write(" ");
                                        }
                                        goto batloingaybd;
                                    }
                                }
                                else if (int.Parse(tach[1]) == 1 || int.Parse(tach[1]) == 3 || int.Parse(tach[1]) == 5 || int.Parse(tach[1]) == 7 || int.Parse(tach[1]) == 8 || int.Parse(tach[1]) == 10 || int.Parse(tach[1]) == 12)
                                {
                                    if (int.Parse(tach[0]) > 31 || int.Parse(tach[0]) < 0)
                                    {
                                        Console.SetCursorPosition(59, 3 + i);
                                        for (int j = 0; j < hd[i].ngaybatdau.Length; j++)
                                        {
                                            Console.Write(" ");
                                        }
                                        goto batloingaybd;
                                    }
                                }
                                else
                                {
                                    if (int.Parse(tach[0]) > 30 || int.Parse(tach[0]) < 0)
                                    {
                                        Console.SetCursorPosition(59, 3 + i);
                                        for (int j = 0; j < hd[i].ngaybatdau.Length; j++)
                                        {
                                            Console.Write(" ");
                                        }
                                        goto batloingaybd;
                                    }
                                }
                            }
                        }
                        break;
                    }
                    while (true)
                    {
                    batloingaykt:
                        Console.SetCursorPosition(79, 3 + i);
                        hd[i].ngayketthuc = Console.ReadLine();
                        string ghep = "";

                        string[] tach = hd[i].ngayketthuc.Split('/');
                        for (int h = 0; h < tach.Length; h++)
                        {
                            ghep += tach[h];
                        }
                        int b;
                        bool c = int.TryParse(ghep, out b);
                        if (c == false || tach.Length != 3)
                        {
                            Console.SetCursorPosition(79, 3 + i);
                            for (int j = 0; j < hd[i].ngayketthuc.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloingaykt;
                        }
                        else if (c == true)
                        {
                            if (int.Parse(tach[2]) < 0)
                            {
                                Console.SetCursorPosition(79, 3 + i);
                                for (int j = 0; j < hd[i].ngayketthuc.Length; j++)
                                {
                                    Console.Write(" ");
                                }
                                goto batloingaykt;
                            }
                            // kiểm tra năm nhuận và tháng 2
                            if (int.Parse(tach[2]) % 4 == 0)
                            {
                                // nếu nhập tháng 2 hơn 29 ngày sẽ nhập lại
                                if (int.Parse(tach[0]) > 29 && int.Parse(tach[1]) == 2)
                                {
                                    Console.SetCursorPosition(79, 3 + i);
                                    for (int j = 0; j < hd[i].ngayketthuc.Length; j++)
                                    {
                                        Console.Write(" ");
                                    }
                                    goto batloingaykt;
                                }
                            }
                            // không phải năm nhuận thì tháng 2 có 28 ngày tối đa, tháng 1,3,5,7,8,10,12 có tối đa 31 ngày
                            //tháng 2,4,6,9,11 có tối đa 30 ngày
                            if (int.Parse(tach[2]) % 4 != 0)
                            {
                                if (int.Parse(tach[1]) == 2)
                                {
                                    if (int.Parse(tach[0]) > 28 || int.Parse(tach[0]) < 0)
                                    {
                                        Console.SetCursorPosition(79, 3 + i);
                                        for (int j = 0; j < hd[i].ngayketthuc.Length; j++)
                                        {
                                            Console.Write(" ");
                                        }
                                        goto batloingaykt;
                                    }
                                }
                                else if (int.Parse(tach[1]) == 1 || int.Parse(tach[1]) == 3 || int.Parse(tach[1]) == 5 || int.Parse(tach[1]) == 7 || int.Parse(tach[1]) == 8 || int.Parse(tach[1]) == 10 || int.Parse(tach[1]) == 12)
                                {
                                    if (int.Parse(tach[0]) > 31 || int.Parse(tach[0]) < 0)
                                    {
                                        Console.SetCursorPosition(79, 3 + i);
                                        for (int j = 0; j < hd[i].ngayketthuc.Length; j++)
                                        {
                                            Console.Write(" ");
                                        }
                                        goto batloingaykt;
                                    }
                                }
                                else
                                {
                                    if (int.Parse(tach[0]) > 30 || int.Parse(tach[0]) < 0)
                                    {
                                        Console.SetCursorPosition(79, 3 + i);
                                        for (int j = 0; j < hd[i].ngayketthuc.Length; j++)
                                        {
                                            Console.Write(" ");
                                        }
                                        goto batloingaykt;
                                    }
                                }
                            }
                        }

                        break;
                    }
                    while (true)
                    {
                    batloingayky:
                        Console.SetCursorPosition(99, 3 + i);
                        hd[i].ngayky = Console.ReadLine();
                        string ghep = "";

                        string[] tach = hd[i].ngayky.Split('/');
                        for (int h = 0; h < tach.Length; h++)
                        {
                            ghep += tach[h];
                        }
                        int b;
                        bool c = int.TryParse(ghep, out b);
                        if (c == false || tach.Length != 3)
                        {
                            Console.SetCursorPosition(99, 3 + i);
                            for (int j = 0; j < hd[i].ngayky.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloingayky;
                        }
                        else if (c == true)
                        {
                            if (int.Parse(tach[2]) < 0)
                            {
                                Console.SetCursorPosition(99, 3 + i);
                                for (int j = 0; j < hd[i].ngayky.Length; j++)
                                {
                                    Console.Write(" ");
                                }
                                goto batloingayky;
                            }
                            // kiểm tra năm nhuận và tháng 2
                            if (int.Parse(tach[2]) % 4 == 0)
                            {
                                // nếu nhập tháng 2 hơn 29 ngày sẽ nhập lại
                                if (int.Parse(tach[0]) > 29 && int.Parse(tach[1]) == 2)
                                {
                                    Console.SetCursorPosition(99, 3 + i);
                                    for (int j = 0; j < hd[i].ngayky.Length; j++)
                                    {
                                        Console.Write(" ");
                                    }
                                    goto batloingayky;
                                }
                            }
                            // không phải năm nhuận thì tháng 2 có 28 ngày tối đa, tháng 1,3,5,7,8,10,12 có tối đa 31 ngày
                            //tháng 2,4,6,9,11 có tối đa 30 ngày
                            if (int.Parse(tach[2]) % 4 != 0)
                            {
                                if (int.Parse(tach[1]) == 2)
                                {
                                    if (int.Parse(tach[0]) > 28 || int.Parse(tach[0]) < 0)
                                    {
                                        Console.SetCursorPosition(99, 3 + i);
                                        for (int j = 0; j < hd[i].ngayky.Length; j++)
                                        {
                                            Console.Write(" ");
                                        }
                                        goto batloingayky;
                                    }
                                }
                                else if (int.Parse(tach[1]) == 1 || int.Parse(tach[1]) == 3 || int.Parse(tach[1]) == 5 || int.Parse(tach[1]) == 7 || int.Parse(tach[1]) == 8 || int.Parse(tach[1]) == 10 || int.Parse(tach[1]) == 12)
                                {
                                    if (int.Parse(tach[0]) > 31 || int.Parse(tach[0]) < 0)
                                    {
                                        Console.SetCursorPosition(99, 3 + i);
                                        for (int j = 0; j < hd[i].ngayky.Length; j++)
                                        {
                                            Console.Write(" ");
                                        }
                                        goto batloingayky;
                                    }
                                }
                                else
                                {
                                    if (int.Parse(tach[0]) > 30 || int.Parse(tach[0]) < 0)
                                    {
                                        Console.SetCursorPosition(99, 3 + i);
                                        for (int j = 0; j < hd[i].ngayky.Length; j++)
                                        {
                                            Console.Write(" ");
                                        }
                                        goto batloingayky;
                                    }
                                }
                            }
                        }
                        break;
                    }
                    while (true)
                    {
                    batloiluongcb:
                        Console.SetCursorPosition(115, 3 + i);
                        hd[i].luongcb = Console.ReadLine();
                        int b;
                        bool c = int.TryParse(hd[i].luongcb, out b);
                        if (c == false)
                        {
                            Console.SetCursorPosition(1, 3 + i);
                            for (int j = 0; j < hd[i].luongcb.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloiluongcb;
                        }
                        else if (int.Parse(hd[i].luongcb) < 0)
                        {
                            Console.SetCursorPosition(115, 3 + i);
                            for (int j = 0; j < hd[i].luongcb.Length; j++)
                            {
                                Console.Write(" ");
                            }
                            goto batloiluongcb;
                        }
                        break;
                    }
                    nhapma += 1;
                }
            }
            if (nhapma == 0)
            {
                do
                {
                    Console.WriteLine("Mã quản lý bạn nhập không tồn tại ");
                    Console.WriteLine("bạn muốn nhập lại hay thoát ");
                    Console.WriteLine("0. Thoát ");
                    Console.WriteLine("1. Nhập lại ");
                    Console.Write("Mời bạn chọn:");
                    chon = int.Parse(Console.ReadLine());
                }
                while (chon != 0 && chon != 1);
                if (chon == 1)
                {
                    goto nhaplaimahd;
                }
            }
        }
    }
    #endregion
    #region file ghi thông tin nhanvien
    static void file(nhanvien[] nv, int a)
    {
        if (a == 0)
        {
            // file lưu số lượng phần tử của mảng
            using (FileStream fileSL = new FileStream("soluongmang.txt", FileMode.Create, FileAccess.ReadWrite))
            {
                StreamWriter ghi = new StreamWriter(fileSL);
                ghi.Write(nv.Length);
                ghi.Flush();
            }
            // file phụ lưu trữ các phần tử mảng phân cách nhau bởi dấu phẩy
            using (FileStream filephu = new FileStream("nhanvien.txt", FileMode.Create, FileAccess.ReadWrite))
            {
                StreamWriter ghi = new StreamWriter(filephu);
                for (int i = 0; i < nv.Length; i++)
                {
                    if (i <= nv.Length - 2 && nv[i].Hoten != null)
                        ghi.Write(nv[i].Manv + ',' + nv[i].Hoten + ',' + nv[i].Namsinh + ',' + nv[i].quequan + ',' + nv[i].CMT + ',');
                    else if (i == nv.Length - 1 && nv[i].Hoten != null)
                        ghi.Write(nv[i].Manv + ',' + nv[i].Hoten + ',' + nv[i].Namsinh + ',' + nv[i].quequan + ',' + nv[i].CMT);
                }
                ghi.Flush();
            }
        }
        else if (a == 1)
        {
            int line1;
            using (FileStream newfile1 = new FileStream("soluongmang.txt", FileMode.Open, FileAccess.Read))
            {
                StreamReader doc1 = new StreamReader(newfile1);
                line1 = int.Parse(doc1.ReadToEnd());
            }
            //đọc file lấy số lượng phần tử của mảng đã lưu
            nv = new nhanvien[line1];
            using (FileStream newfile2 = new FileStream("nhanvien.txt", FileMode.Open, FileAccess.Read))
            {
                StreamReader doc2 = new StreamReader(newfile2);
                string line2 = doc2.ReadToEnd();
                if (line2[line2.Length - 1] == ',')
                {
                    line2.Remove(line2.Length - 1);
                }
                else if (line2[0] == ',')
                {
                    line2.Remove(0, 1);
                }
                int c = 0;
                string[] tach = line2.Split(',');
                for (int j = 0; j < nv.Length; j++)
                {
                    nv[j].Manv = tach[c + 0];
                    nv[j].Hoten = tach[c + 1];
                    nv[j].Namsinh = tach[c + 2];
                    nv[j].quequan = tach[c + 3];
                    nv[j].CMT = tach[c + 4];
                    c += 5;
                }
            }
        }
        // ghi thêm vào cuối
        else if (a == 2)
        {
            int dem = 0;
            using (FileStream fileSLd = new FileStream("soluongmang.txt", FileMode.Open, FileAccess.ReadWrite))
            {
                StreamReader doc = new StreamReader(fileSLd);
                dem = int.Parse(doc.ReadToEnd());
            }
            using (FileStream fileSLw = new FileStream("soluongmang.txt", FileMode.Create, FileAccess.ReadWrite))
            {
                StreamWriter ghi = new StreamWriter(fileSLw);
                dem = dem + nv.Length;
                ghi.Write(dem);
                ghi.Flush();
            }
            using (FileStream filephu = new FileStream("nhanvien.txt", FileMode.Append, FileAccess.Write))
            {
                StreamWriter ghi = new StreamWriter(filephu);
                ghi.Write(",");
                for (int i = 0; i < nv.Length; i++)
                {
                    if (i <= nv.Length - 2)
                        ghi.Write(nv[i].Manv + ',' + nv[i].Hoten + ',' + nv[i].Namsinh + ',' + nv[i].quequan + ',' + nv[i].CMT + ',');
                    else if (i == nv.Length - 1)
                        ghi.Write(nv[i].Manv + ',' + nv[i].Hoten + ',' + nv[i].Namsinh + ',' + nv[i].quequan + ',' + nv[i].CMT);
                }
                ghi.Flush();
            }
        }
    }
    #endregion
    #region ghi file quản lý hợp đồng
    static void file2(quanlyhd[] qlhd, int a)
    {
        if (a == 0)
        {
            // file lưu số lượng phần tử của mảng
            using (FileStream fileSL = new FileStream("soluongmang2.txt", FileMode.Create, FileAccess.ReadWrite))
            {
                StreamWriter ghi = new StreamWriter(fileSL);
                ghi.Write(qlhd.Length);
                ghi.Flush();
            }
            // file phụ lưu trữ các phần tử mảng phân cách nhau bởi dấu phẩy
            using (FileStream filephu = new FileStream("quanly.txt", FileMode.Create, FileAccess.ReadWrite))
            {
                StreamWriter ghi = new StreamWriter(filephu);
                for (int i = 0; i < qlhd.Length; i++)
                {
                    if (i <= qlhd.Length - 2 && qlhd[i].Hoten != null)
                        ghi.Write(qlhd[i].Maql + ',' + qlhd[i].Hoten + ',' + qlhd[i].diachi + ',' + qlhd[i].CMT + ',' + qlhd[i].sdt + ',');
                    else if (i == qlhd.Length - 1 && qlhd[i].Hoten != null)
                        ghi.Write(qlhd[i].Maql + ',' + qlhd[i].Hoten + ',' + qlhd[i].diachi + ',' + qlhd[i].CMT + ',' + qlhd[i].sdt);
                }
                ghi.Flush();
            }
        }
        else if (a == 1)
        {
            int line1;
            using (FileStream newfile1 = new FileStream("soluongmang2.txt", FileMode.Open, FileAccess.Read))
            {
                StreamReader doc1 = new StreamReader(newfile1);
                line1 = int.Parse(doc1.ReadToEnd());
            }
            //đọc file lấy số lượng phần tử của mảng đã lưu
            qlhd = new quanlyhd[line1];
            using (FileStream newfile2 = new FileStream("quanly.txt", FileMode.Open, FileAccess.Read))
            {
                StreamReader doc2 = new StreamReader(newfile2);
                string line2 = doc2.ReadToEnd();
                if (line2[line2.Length - 1] == ',')
                {
                    line2.Remove(line2.Length - 1);
                }
                else if (line2[0] == ',')
                {
                    line2.Remove(0, 1);
                }
                int c = 0;
                string[] tach = line2.Split(',');
                for (int j = 0; j < qlhd.Length; j++)
                {
                    qlhd[j].Maql = tach[c + 0];
                    qlhd[j].Hoten = tach[c + 1];
                    qlhd[j].diachi = tach[c + 2];
                    qlhd[j].CMT = tach[c + 3];
                    qlhd[j].sdt = tach[c + 4];
                    c += 5;
                }
            }
        }
        // ghi thêm vào cuối
        else if (a == 2)
        {
            int dem = 0;
            using (FileStream fileSLd = new FileStream("soluongmang2.txt", FileMode.Open, FileAccess.ReadWrite))
            {
                StreamReader doc = new StreamReader(fileSLd);
                dem = int.Parse(doc.ReadToEnd());
            }
            using (FileStream fileSLw = new FileStream("soluongmang2.txt", FileMode.Create, FileAccess.ReadWrite))
            {
                StreamWriter ghi = new StreamWriter(fileSLw);
                dem = dem + nv.Length;
                ghi.Write(dem);
                ghi.Flush();
            }
            using (FileStream filephu = new FileStream("quanly.txt", FileMode.Append, FileAccess.Write))
            {
                StreamWriter ghi = new StreamWriter(filephu);
                ghi.Write(",");
                for (int i = 0; i < nv.Length; i++)
                {
                    if (i <= nv.Length - 2)
                        ghi.Write(nv[i].Manv + ',' + nv[i].Hoten + ',' + nv[i].Namsinh + ',' + nv[i].quequan + ',' + nv[i].CMT + ',');
                    else if (i == nv.Length - 1)
                        ghi.Write(nv[i].Manv + ',' + nv[i].Hoten + ',' + nv[i].Namsinh + ',' + nv[i].quequan + ',' + nv[i].CMT);
                }
                ghi.Flush();
            }
        }
    }
    #endregion
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        Console.SetCursorPosition(50, 10);
        Console.WriteLine("Chúc buổi sáng lucky ");
    quaylaimenu1:
        do
        {
        batloichon1:
            try
            {
                Console.Clear();
                Console.SetCursorPosition(40, 7);
                for (int i = 0; i < 35; i++)
                {
                    Console.Write("_");
                }
                Console.SetCursorPosition(41, 10);
                for (int i = 0; i < 34; i++)
                {
                    Console.Write("_");
                }
                for (int i = 0; i < 21; i++)
                {
                    Console.SetCursorPosition(40, 8 + i);
                    Console.Write("|");
                }
                for (int i = 0; i < 21; i++)
                {
                    Console.SetCursorPosition(75, 8 + i);
                    Console.Write("|");
                }
                Console.SetCursorPosition(41, 28);
                for (int i = 0; i < 34; i++)
                {
                    Console.Write("_");
                }
                Console.SetCursorPosition(55, 9);
                Console.WriteLine("Menu ");
                Console.SetCursorPosition(45, 12);
                Console.WriteLine("1. Nhập thông tin ");
                Console.SetCursorPosition(45, 14);
                Console.WriteLine("2. Sửa đổi thông tin ");
                Console.SetCursorPosition(45, 16);
                Console.WriteLine("3. Xóa thông tin ");
                Console.SetCursorPosition(45, 18);
                Console.WriteLine("4. Hiển thị thông tin ");
                Console.SetCursorPosition(45, 20);
                Console.WriteLine("5. Tìm kiếm  thông tin ");
                Console.SetCursorPosition(45, 22);
                Console.WriteLine("6. Thống kê thông tin ");
                Console.SetCursorPosition(45, 24);
                Console.WriteLine("0. thoát ");
                Console.SetCursorPosition(45, 26);
                Console.Write("mời bạn chọn :");
                chon = int.Parse(Console.ReadLine());
            }
            catch
            {
                goto batloichon1;
            }
        }
        while (chon != 0 && chon != 1 && chon != 2 && chon != 3 && chon != 4 && chon != 5 && chon != 6);
        switch (chon)
        {
            case 1:
                {
                quaylaimenu2:
                    do
                    {
                    batloichon2:
                        try
                        {
                            Console.Clear();
                            Console.SetCursorPosition(55, 9);
                            Console.WriteLine("Menu ");
                            Console.SetCursorPosition(45, 12);
                            Console.WriteLine("1. Nhập thông tin nhân viên ");
                            Console.SetCursorPosition(45, 14);
                            Console.WriteLine("2. Nhập thông tin quản lý hợp đồng ");
                            Console.SetCursorPosition(45, 16);
                            Console.WriteLine("3. Nhập thông tin bằng cấp ");
                            Console.SetCursorPosition(45, 18);
                            Console.WriteLine("4. Nhập thông tin hợp đồng");
                            Console.SetCursorPosition(45, 20);
                            Console.WriteLine("0. thoát ");
                            Console.SetCursorPosition(45, 22);
                            Console.Write("mời bạn chọn :");
                            chon = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            goto batloichon2;
                        }
                    }
                    while (chon != 0 && chon != 1 && chon != 2 && chon != 3 && chon != 4);
                    switch (chon)
                    {
                        case 1:
                            {
                                Console.Clear();
                                Console.WriteLine("Nhập số lượng nhân viên :");
                                n = int.Parse(Console.ReadLine());
                                nv = new nhanvien[n];
                                nhapnhanvien(ref nv);
                                file(nv, 0);
                                Console.WriteLine("nhấn enter để quay trở lại ");
                                Console.ReadKey(true);
                                goto quaylaimenu2;
                            }
                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine("nhập số lượng quản lý hợp đồng :");
                                n = int.Parse((string)Console.ReadLine());
                                qlhd = new quanlyhd[n];
                                nhapquanly(ref qlhd);
                                file2(qlhd, 0);
                                Console.WriteLine("nhấn enter để quay trở lại ");
                                Console.ReadKey(true);
                                goto quaylaimenu2;
                            }
                        case 3:
                            {
                                Console.Clear();
                                nhapbangcap(ref bc, qlhd);
                                Console.WriteLine("nhấn enter để quay trở lại ");
                                Console.ReadKey(true);
                                goto quaylaimenu2;
                            }
                        case 4:
                            {
                                Console.Clear();
                                Console.WriteLine("Nhập số lượng hợp đồng :");
                                n = int.Parse(Console.ReadLine());
                                hd = new hopdong[n];
                                nhaphopdong(ref hd, nv, qlhd);
                                Console.WriteLine("nhấn enter để quay trở lại ");
                                Console.ReadKey(true);
                                goto quaylaimenu2;
                            }
                        case 0:
                            {
                                goto quaylaimenu2;
                            }
                    }
                    break;
                }
            case 2:
                {
                quaylaimenu3:
                    do
                    {
                    batloichon3:
                        try
                        {
                            Console.Clear();
                            Console.SetCursorPosition(55, 9);
                            Console.WriteLine("Menu ");
                            Console.SetCursorPosition(45, 12);
                            Console.WriteLine("1. Sửa thông tin nhân viên ");
                            Console.SetCursorPosition(45, 14);
                            Console.WriteLine("2. Sửa thông tin quản lý hợp đồng ");
                            Console.SetCursorPosition(45, 16);
                            Console.WriteLine("3. Sửa thông tin bằng cấp ");
                            Console.SetCursorPosition(45, 18);
                            Console.WriteLine("4. Sửa thông tin hợp đồng");
                            Console.SetCursorPosition(45, 20);
                            Console.WriteLine("0. thoát ");
                            Console.SetCursorPosition(45, 22);
                            Console.Write("mời bạn chọn :");
                            chon = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            goto batloichon3;
                        }
                    }
                    while (chon != 0 && chon != 1 && chon != 2 && chon != 3 && chon != 4);
                    switch (chon)
                    {
                        case 1:
                            {
                                Console.Clear();
                                file(nv, 1);
                                suathongtin(ref nv, ref qlhd, ref bc, ref hd, 1, ref chon);
                                Console.WriteLine("nhấn enter để quay trở lại ");
                                Console.ReadKey(true);
                                goto quaylaimenu3;
                            }
                        case 2:
                            {
                                Console.Clear();
                                file2(qlhd, 1);
                                suathongtin(ref nv, ref qlhd, ref bc, ref hd, 2, ref chon);
                                Console.WriteLine("nhấn enter để quay trở lại ");
                                Console.ReadKey(true);
                                goto quaylaimenu3;
                            }
                        case 3:
                            {
                                Console.Clear();
                                suathongtin(ref nv, ref qlhd, ref bc, ref hd, 3, ref chon);
                                Console.WriteLine("nhấn enter để quay trở lại ");
                                Console.ReadKey(true);
                                goto quaylaimenu3;
                            }
                        case 4:
                            {
                                Console.Clear();
                                suathongtin(ref nv, ref qlhd, ref bc, ref hd, 4, ref chon);
                                Console.WriteLine("nhấn enter để quay trở lại ");
                                Console.ReadKey(true);
                                goto quaylaimenu3;
                            }
                    }
                    break;
                }
            case 0:
                {
                    goto quaylaimenu1;
                }
        }
    }

}
