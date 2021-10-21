using Keysight.Plugins.Python;

[assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
[assembly: System.Reflection.AssemblyFileVersion("1.0.0.0")]
[assembly: System.Reflection.AssemblyInformationalVersion("1.0.0.0")]
[assembly: System.Runtime.InteropServices.GuidAttribute("94bb4623-6561-464b-877b-49356aac818e")]
namespace Python.FunctionGenerator
{
 [PythonWrapper.PythonName("FunctionGenerator.FunctionGenerator.FunctionGenerator")]
 [OpenTap.DisplayAttribute("Func", "connect Function Generator", "Function")]
 public class FunctionGenerator : Keysight.OpenTap.Plugins.Python.PythonInstrumentWrapper
 {
  public override void load_instance()
  {
   load("FunctionGenerator", "FunctionGenerator");
  }

  [OpenTap.DisplayAttribute("VISA Address", "The VISA address of the instrument.")]
  public System.String visa_address
  {
   get
   {
    return (System.String)this.getValue("visa_address", typeof(System.String));
   }

   set
   {
    this.setValue("visa_address", value);
   }
  }

  [OpenTap.DisplayAttribute("Timeout", "VISA Timeout in milliseconds.")]
  public System.Int32 Timeout
  {
   get
   {
    return (System.Int32)this.getValue("Timeout", typeof(System.Int32));
   }

   set
   {
    this.setValue("Timeout", value);
   }
  }
 }

 [PythonWrapper.PythonName("FunctionGenerator.TestPlan.IdnQuery")]
 [OpenTap.DisplayAttribute(Name: "IdnQuery", Description: "An Example", Groups: new System.String[]{"FuncGenerator"})]
 public class IdnQuery : Keysight.OpenTap.Plugins.Python.PythonStepWrapper
 {
  public override void load_instance()
  {
   load("IdnQuery", "FunctionGenerator");
  }

  [OpenTap.DisplayAttribute("Test Insturment", "", "Resources", -100)]
  public FunctionGenerator Func
  {
   get
   {
    return (FunctionGenerator)this.getValue("Func", typeof(FunctionGenerator));
   }

   set
   {
    this.setValue("Func", value);
   }
  }
 }

 [PythonWrapper.PythonName("FunctionGenerator.TestPlan.OutPut")]
 [OpenTap.DisplayAttribute(Name: "Output", Description: "An Example", Groups: new System.String[]{"FuncGenerator"})]
 public class OutPut : Keysight.OpenTap.Plugins.Python.PythonStepWrapper
 {
  public override void load_instance()
  {
   load("OutPut", "FunctionGenerator");
  }

  [OpenTap.DisplayAttribute("Test Insturment", "", "Resources", -100)]
  public FunctionGenerator Func
  {
   get
   {
    return (FunctionGenerator)this.getValue("Func", typeof(FunctionGenerator));
   }

   set
   {
    this.setValue("Func", value);
   }
  }

  [OpenTap.DisplayAttribute("On and Off the Generator", "this is the fature turn on or off the channel", "onOff", -100)]
  public System.String OnOff
  {
   get
   {
    return (System.String)this.getValue("OnOff", typeof(System.String));
   }

   set
   {
    this.setValue("OnOff", value);
   }
  }
 }

 [PythonWrapper.PythonName("FunctionGenerator.TestPlan.Generate")]
 [OpenTap.DisplayAttribute(Name: "Generate", Description: "An Example", Groups: new System.String[]{"FuncGenerator"})]
 public class Generate : Keysight.OpenTap.Plugins.Python.PythonStepWrapper
 {
  public override void load_instance()
  {
   load("Generate", "FunctionGenerator");
  }

  [OpenTap.DisplayAttribute("Test Insturment", "", "Resources", 1)]
  public FunctionGenerator Func
  {
   get
   {
    return (FunctionGenerator)this.getValue("Func", typeof(FunctionGenerator));
   }

   set
   {
    this.setValue("Func", value);
   }
  }

  [OpenTap.UnitAttribute("Hz")]
  [OpenTap.DisplayAttribute("Frequency", "Set the frequncy to generate", "Parameter", 2)]
  public System.Double Frequency
  {
   get
   {
    return (System.Double)this.getValue("Frequency", typeof(System.Double));
   }

   set
   {
    this.setValue("Frequency", value);
   }
  }

  [OpenTap.UnitAttribute("V")]
  [OpenTap.DisplayAttribute("Amplitude", "Set the voltage to generate", "Parameter", 3)]
  public System.Double Amplitude
  {
   get
   {
    return (System.Double)this.getValue("Amplitude", typeof(System.Double));
   }

   set
   {
    this.setValue("Amplitude", value);
   }
  }

  [OpenTap.UnitAttribute("V")]
  [OpenTap.DisplayAttribute("Offset", "Set the offset to generate", "Parameter", 4)]
  public System.Double Offset
  {
   get
   {
    return (System.Double)this.getValue("Offset", typeof(System.Double));
   }

   set
   {
    this.setValue("Offset", value);
   }
  }
 }
}