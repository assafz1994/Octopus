using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    internal static class RelationsConsts
    {
        public static readonly (Guid guid, string name)[] Buyers =
        {
            (new Guid("00000000-0000-0000-0000-000000000011"), "buyer1"),
            (new Guid("00000000-0000-0000-0000-000000000012"), "buyer2"),
            (new Guid("00000000-0000-0000-0000-000000000013"), "buyer3")
        };

        public static readonly (Guid guid, string name)[] Sellers =
        {
            (new Guid("00000000-0000-0000-0000-000000000021"), "seller1"),
            (new Guid("00000000-0000-0000-0000-000000000022"), "seller2"),
            (new Guid("00000000-0000-0000-0000-000000000023"), "seller3")
        };

        public static readonly Dictionary<(string field1, string field2), (Guid guid1, Guid guid2)[]> FieldsValuesMappings =
            new Dictionary<(string field1, string field2), (Guid guid1, Guid guid2)[]>
            {
                {
                    ("buyFrom", "sellTo"),
                    new[]
                    {
                        (new Guid("00000000-0000-0000-0000-000000000011"),
                            new Guid("00000000-0000-0000-0000-000000000021"))
                    }
                },
                {
                    ("buyFromMany", "sellToMany"), new[]
                    {
                        (new Guid("00000000-0000-0000-0000-000000000011"),
                            new Guid("00000000-0000-0000-0000-000000000021")),
                        (new Guid("00000000-0000-0000-0000-000000000011"),
                            new Guid("00000000-0000-0000-0000-000000000022"))
                    }
                },
                {
                    ("favoriteSeller", ""), new[]
                    {
                        (new Guid("00000000-0000-0000-0000-000000000013"),
                            new Guid("00000000-0000-0000-0000-000000000023"))
                    }
                },
                {
                    ("favoriteSellerMany", ""), new[]
                    {
                        (new Guid("00000000-0000-0000-0000-000000000013"),
                            new Guid("00000000-0000-0000-0000-000000000023")),
                        (new Guid("00000000-0000-0000-0000-000000000013"),
                            new Guid("00000000-0000-0000-0000-000000000022"))
                    }
                },
                {
                    ("", "favoriteBuyer"), new[]
                    {
                        (new Guid("00000000-0000-0000-0000-000000000011"),
                            new Guid("00000000-0000-0000-0000-000000000021"))
                    }
                },
                {
                    ("", "favoriteBuyerMany"), new[]
                    {
                        (new Guid("00000000-0000-0000-0000-000000000011"),
                            new Guid("00000000-0000-0000-0000-000000000023")),
                        (new Guid("00000000-0000-0000-0000-000000000013"),
                            new Guid("00000000-0000-0000-0000-000000000023"))
                    }
                }
            };
    }
}
