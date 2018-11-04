using System;
using System.Linq;
using SalesWebMvc.Models.Enums;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
                return; //DB has been  seeded

            //Department
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            //Sellers
            Seller s1 = new Seller(1, "Bob Brown", "bob@bobo.com", new DateTime(1980, 04, 18), 1000.0, d1);
            Seller s2 = new Seller(2, "Mary Jane", "mary@bobo.com", new DateTime(1990, 03, 23), 700.0, d4);
            Seller s3 = new Seller(3, "Jhon Scoot", "jhon@bobo.com", new DateTime(1976, 10, 25), 400.5, d2);
            Seller s4 = new Seller(4, "Drew Scoot", "drew@bobo.com", new DateTime(1980, 04, 01), 1200.0, d1);
            Seller s5 = new Seller(5, "Martha Red", "martha@bobo.com", new DateTime(1996, 02, 23), 1450.3, d2);
            Seller s6 = new Seller(6, "Alex Pink", "alex@bobo.com", new DateTime(1994, 03, 05), 999.7, d3);

            //SalesRecord
            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 29), 10000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 10, 10), 9000.0, SaleStatus.Canceled, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 08, 10), 100.0, SaleStatus.Canceled, s6);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 11, 02), 450.0, SaleStatus.Pending, s3);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 10, 25), 525.89, SaleStatus.Canceled, s4);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 07, 20), 789.98, SaleStatus.Canceled, s6);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2018, 11, 01), 7450.9, SaleStatus.Pending, s5);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2018, 05, 28), 578.9, SaleStatus.Billed, s2);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2018, 10, 02), 12500.9, SaleStatus.Billed, s3);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2018, 10, 01), 465.9, SaleStatus.Billed, s4);
            SalesRecord r11 = new SalesRecord(11, new DateTime(2018, 11, 05), 784.9, SaleStatus.Pending, s1);
            SalesRecord r12 = new SalesRecord(12, new DateTime(2018, 04, 08), 15000.0, SaleStatus.Canceled, s4);

            //Add to DB
            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12);

            _context.SaveChanges();
        }
    }
}
