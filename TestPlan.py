import os
import sys
import clr

clr.AddReference("System")
clr.AddReference("System.Collections")

import System
from System import Array, Double, Byte, Int32, String, Boolean
from System.Collections.Generic import List
from System.ComponentModel import BrowsableAttribute

import System.Xml
from System.Xml.Serialization import XmlIgnoreAttribute

import OpenTap
from PythonTap import *
from .FunctionGenerator import *
import pyvisa


@Attribute(OpenTap.DisplayAttribute, Name = "IdnQuery", Description= "An Example", Groups = ["FuncGenerator"])
class IdnQuery(TestStep):
    def __init__(self):
        super(IdnQuery, self).__init__() # the base class initializer must be invoked.

        prop0 = self.AddProperty("Func", None, FunctionGenerator)
        prop0.AddAttribute(OpenTap.DisplayAttribute, "Test Insturment", "", "Resources", -100)

    def Run(self):
        self.id = self.Func.inst.query("*IDN?")
        self.Info(self.id)

@Attribute(OpenTap.DisplayAttribute, Name = "Output", Description= "An Example", Groups = ["FuncGenerator"])
class OutPut(TestStep):
    def __init__(self):
        super(OutPut, self).__init__() # the base class initializer must be invoked.

        prop0 = self.AddProperty("Func", None, FunctionGenerator)
        prop0.AddAttribute(OpenTap.DisplayAttribute, "Test Insturment", "", "Resources", -100)

        prop1 = self.AddProperty("OnOff", "On", String)
        prop1.AddAttribute(OpenTap.DisplayAttribute, "On and Off the Generator", "this is the fature turn on or off the channel", "onOff", -100)

    def Run(self):
        self.Func.inst.write(f"OUTPut1 {self.OnOff}")
        self.Info(f"Output turned {self.OnOff}")

@Attribute(OpenTap.DisplayAttribute, Name = "Generate", Description= "An Example", Groups = ["FuncGenerator"])
class Generate(TestStep):
    def __init__(self):
        super(Generate, self).__init__() # the base class initializer must be invoked.

        prop0 = self.AddProperty("Func", None, FunctionGenerator)
        prop0.AddAttribute(OpenTap.DisplayAttribute, "Test Insturment", "", "Resources", 1)

        prop1 = self.AddProperty("Frequency", 10E+06, Double)
        prop1.AddAttribute(OpenTap.UnitAttribute, "Hz")
        prop1.AddAttribute(OpenTap.DisplayAttribute, "Frequency", "Set the frequncy to generate", "Parameter", 2)

        prop2 = self.AddProperty("Amplitude", 1, Double)
        prop2.AddAttribute(OpenTap.UnitAttribute, "V")
        prop2.AddAttribute(OpenTap.DisplayAttribute, "Amplitude", "Set the voltage to generate", "Parameter", 3)

        prop3 = self.AddProperty("Offset", 0, Double)
        prop3.AddAttribute(OpenTap.UnitAttribute, "V")
        prop3.AddAttribute(OpenTap.DisplayAttribute, "Offset", "Set the offset to generate", "Parameter", 4)


    def Run(self):
        self.Func.inst.write(f"SOURce1:APPLy:SINusoid {self.Frequency},{self.Amplitude}, {self.Offset}")
        self.Info(f"Signal generated with Frequency: {self.Frequency}Hz,Voltage: {self.Amplitude}V, Offset = {self.Offset}V")