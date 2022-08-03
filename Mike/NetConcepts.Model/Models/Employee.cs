using NetConcepts.Model.Attributes;
using System;

namespace NetConcepts.Model.Models {
  [MyEmployeeMetaDataAttibute(Order = 1, Tag = "Test")]
  internal class Employee {
    public string Name { get; }

    public Guid Id { get; }

    public string EmpCode { get; }

    public Employee(string name, string code) {
      Name = name;
      EmpCode = code;
      Id = Guid.NewGuid();
    }

    public override string ToString() {
      return string.Concat(EmpCode, ":", Name);
    }
  }
}
