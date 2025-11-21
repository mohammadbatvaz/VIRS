using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VIRS.Domain.Core.CarModelAgg.Entities;

namespace VIRS.Infra.DataBase.EFCoreSqlServer.Configurations
{
    public class CarModelConfigurations : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.HasKey(cm => cm.Id);

            builder.HasIndex(cm => new { cm.Manufacturer, cm.Family, cm.Name })
                .IsUnique();

            builder.Property(cm => cm.Family)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(cm => cm.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(cm => cm.Manufacturer)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.HasData(
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000001"), Manufacturer = "ایرانخودرو", Family = "پژو", Name = "405 GLX" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000002"), Manufacturer = "ایرانخودرو", Family = "پژو", Name = "405 SLX" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000003"), Manufacturer = "ایرانخودرو", Family = "پژو", Name = "پارس" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000004"), Manufacturer = "ایرانخودرو", Family = "پژو", Name = "پارس TU5" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000005"), Manufacturer = "ایرانخودرو", Family = "پژو", Name = "پارس LX" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000006"), Manufacturer = "ایرانخودرو", Family = "پژو", Name = "پارس XU7P" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000007"), Manufacturer = "ایرانخودرو", Family = "پژو", Name = "206 Type 2" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000008"), Manufacturer = "ایرانخودرو", Family = "پژو", Name = "206 Type 5" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000009"), Manufacturer = "ایرانخودرو", Family = "پژو", Name = "206 SD V8" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-00000000000A"), Manufacturer = "ایرانخودرو", Family = "پژو", Name = "207i دستی" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-00000000000B"), Manufacturer = "ایرانخودرو", Family = "پژو", Name = "207i اتوماتیک" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-00000000000C"), Manufacturer = "ایرانخودرو", Family = "پژو", Name = "207i پانوراما" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-00000000000D"), Manufacturer = "ایرانخودرو", Family = "پژو", Name = "207i MC" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-00000000000E"), Manufacturer = "ایرانخودرو", Family = "پژو", Name = "207i SD" },

                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-00000000000F"), Manufacturer = "ایرانخودرو", Family = "سمند", Name = "LX" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000010"), Manufacturer = "ایرانخودرو", Family = "سمند", Name = "LX EF7" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000011"), Manufacturer = "ایرانخودرو", Family = "سمند", Name = "EF7 بنزینی" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000012"), Manufacturer = "ایرانخودرو", Family = "سمند", Name = "EF7 دوگانه‌سوز" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000013"), Manufacturer = "ایرانخودرو", Family = "سمند", Name = "SE" },

                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000014"), Manufacturer = "ایرانخودرو", Family = "سورن", Name = "ELX" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000015"), Manufacturer = "ایرانخودرو", Family = "سورن", Name = "ELX EF7" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000016"), Manufacturer = "ایرانخودرو", Family = "سورن", Name = "پلاس" },

                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000017"), Manufacturer = "ایرانخودرو", Family = "دنا", Name = "عادی" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000018"), Manufacturer = "ایرانخودرو", Family = "دنا", Name = "پلاس" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000019"), Manufacturer = "ایرانخودرو", Family = "دنا", Name = "پلاس توربو" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-00000000001A"), Manufacturer = "ایرانخودرو", Family = "دنا", Name = "پلاس 6 سرعته" },

                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-00000000001B"), Manufacturer = "ایرانخودرو", Family = "رانا", Name = "عادی" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-00000000001C"), Manufacturer = "ایرانخودرو", Family = "رانا", Name = "پلاس" },

                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-00000000001D"), Manufacturer = "ایرانخودرو", Family = "تارا", Name = "V1 دستی" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-00000000001E"), Manufacturer = "ایرانخودرو", Family = "تارا", Name = "V2 اتوماتیک" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-00000000001F"), Manufacturer = "ایرانخودرو", Family = "تارا", Name = "LX" },
                new CarModel { Id = Guid.Parse("10000000-0000-0000-0000-000000000020"), Manufacturer = "ایرانخودرو", Family = "تارا", Name = "6AT جدید" },

                // Saipa
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000001"), Manufacturer = "سایپا", Family = "پراید", Name = "111" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000002"), Manufacturer = "سایپا", Family = "پراید", Name = "131" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000003"), Manufacturer = "سایپا", Family = "پراید", Name = "132" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000004"), Manufacturer = "سایپا", Family = "پراید", Name = "141" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000005"), Manufacturer = "سایپا", Family = "پراید", Name = "SE" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000006"), Manufacturer = "سایپا", Family = "پراید", Name = "LE" },

                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000007"), Manufacturer = "سایپا", Family = "تیبا", Name = "صندوق‌دار" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000008"), Manufacturer = "سایپا", Family = "تیبا", Name = "2" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000009"), Manufacturer = "سایپا", Family = "تیبا", Name = "SX" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-00000000000A"), Manufacturer = "سایپا", Family = "تیبا", Name = "EX" },

                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-00000000000B"), Manufacturer = "سایپا", Family = "ساینا", Name = "عادی" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-00000000000C"), Manufacturer = "سایپا", Family = "ساینا", Name = "EX" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-00000000000D"), Manufacturer = "سایپا", Family = "ساینا", Name = "SX" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-00000000000E"), Manufacturer = "سایپا", Family = "ساینا", Name = "پلاس" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-00000000000F"), Manufacturer = "سایپا", Family = "ساینا", Name = "پلاس اتوماتیک" },

                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000010"), Manufacturer = "سایپا", Family = "کوئیک", Name = "عادی" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000011"), Manufacturer = "سایپا", Family = "کوئیک", Name = "R" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000012"), Manufacturer = "سایپا", Family = "کوئیک", Name = "S" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000013"), Manufacturer = "سایپا", Family = "کوئیک", Name = "GX" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000014"), Manufacturer = "سایپا", Family = "کوئیک", Name = "GXR" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000015"), Manufacturer = "سایپا", Family = "کوئیک", Name = "اتوماتیک" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000016"), Manufacturer = "سایپا", Family = "کوئیک", Name = "R اتوماتیک" },

                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000017"), Manufacturer = "سایپا", Family = "شاهین", Name = "S" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000018"), Manufacturer = "سایپا", Family = "شاهین", Name = "G" },
                new CarModel { Id = Guid.Parse("20000000-0000-0000-0000-000000000019"), Manufacturer = "سایپا", Family = "شاهین", Name = "اتوماتیک" }
);
        }
    }
}