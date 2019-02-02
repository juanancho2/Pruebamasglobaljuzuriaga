using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Entities
{
    [DataContract]
    public class HourlyEmployeeDTO : IEmployeeDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ContractTypeName { get; set; }
        [DataMember]
        public int RoleId { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public string RoleDescription { get; set; }
        [DataMember]
        public float HourlySalary { get; set; }
        [DataMember]
        public float MonthtlySalary { get; set; }
        [DataMember]
        public float AnnualSalary { get { return 120 * MonthtlySalary * 12; } }
    }
}
