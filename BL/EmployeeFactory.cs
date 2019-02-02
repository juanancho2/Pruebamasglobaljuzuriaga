using BL.Exceptions;
using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BL
{
    class EmployeeFactory : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IEmployeeDTO));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            var props = jo.Properties().ToList();

            try
            {
                if (props.Any(pi => string.Equals(pi.Name, "contractTypeName", StringComparison.OrdinalIgnoreCase)))
                {
                    var contractType = props[2].Value;
                    if (contractType.ToString().Equals("HourlySalaryEmployee"))
                    {
                        return new HourlyEmployeeDTO()
                        {
                            Id = Convert.ToInt32(props[0].Value),
                            Name = props[1].Value.ToString(),
                            ContractTypeName = props[2].Value.ToString(),
                            RoleId = Convert.ToInt32(props[3].Value),
                            RoleName = props[4].Value.ToString(),
                            RoleDescription = props[5].Value.ToString(),
                            HourlySalary = Convert.ToInt32(props[6].Value),
                            MonthtlySalary = Convert.ToInt32(props[7].Value)
                        };
                    }
                    return new MonthlyEmployeeDTO()
                    {
                        Id = Convert.ToInt32(props[0].Value),
                        Name = props[1].Value.ToString(),
                        ContractTypeName = props[2].Value.ToString(),
                        RoleId = Convert.ToInt32(props[3].Value),
                        RoleName = props[4].Value.ToString(),
                        RoleDescription = props[5].Value.ToString(),
                        HourlySalary = Convert.ToInt32(props[6].Value),
                        MonthtlySalary = Convert.ToInt32(props[7].Value)
                    };
                }

            }
            catch (Exception)
            {
                throw new ParsingFailedException("Error en el proceso de parseo.");
            }

            return null;
        }
                
        /// <summary>
        /// Se deja sin implementar, debido a que no se necesitan hacer peticiones POST o PUT
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
          //  throw new NotImplementedException();
        }
    }
}
