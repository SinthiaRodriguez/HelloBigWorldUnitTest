using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiNetCore5.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PruebaEnumController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            var tender = EnumHelper.GetDictionary<Pareno>();
            return Ok(tender);
        }
    }


    public static class EnumHelper
    {
        private static readonly Dictionary<Type, Dictionary<Int64, String>> _typeDictionary
            = new Dictionary<Type, Dictionary<Int64, String>>();

        static EnumHelper()
        {
            _typeDictionary = new Dictionary<Type, Dictionary<Int64, String>>();
            AddEnumToDictionary<Pareno>();
        }

        public static IReadOnlyDictionary<Int64, String> GetDictionary<TEnum>() where TEnum : Enum
        {
            _typeDictionary.TryGetValue(typeof(TEnum), out Dictionary<Int64, String> result);
            return result;
        }

        private static void AddEnumToDictionary<TEnum>() where TEnum : Enum
        {
            Type type = typeof(TEnum);
            _typeDictionary.Add(type, GetEnumDictionary(type));
        }

        private static Dictionary<Int64, String> GetEnumDictionary(Type type)
        {
            Dictionary<Int64, String> result = new Dictionary<Int64, String>();
            Array values = Enum.GetValues(type);
            String[] names = Enum.GetNames(type);
            for (Int32 i = 0; i < values.Length; i++)
                result.Add(Convert.ToInt64(values.GetValue(i)), names[i]);
            return result;
        }
    }

    public enum Pareno : byte
    {
        Parent = 0,
        Brother = 1,
        Cousin = 2,
        Aunt = 3,
        GrandFather = 4,
        FatherInLaw = 5,
        BrotherInLaw = 6,
        CloseFriend = 7,
        FellowStudy = 8,
        CoWorker = 9,
        ChurchMember = 10,
        SportsTeamMember = 11,
        Other = 12
    }

}
