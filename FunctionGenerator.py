"""
 A basic example of how to define a instrument driver.
"""

from PythonTap import *
from System import Double, String, Int32
import OpenTap
import pyvisa as visa

@Attribute(OpenTap.DisplayAttribute, "Func", "connect Function Generator", "Function")
class FunctionGenerator(Instrument):
    def __init__(self):
        super(FunctionGenerator, self).__init__() # The base class initializer must be invoked.
        self.Name = "FunctionG"

        prop0 = self.AddProperty("visa_address", "TCPIP0::10.72.59.79::inst0::INSTR", String)
        prop0.AddAttribute(OpenTap.DisplayAttribute, "VISA Address", "The VISA address of the instrument.")

        prop1 = self.AddProperty("Timeout", 10000, Int32)
        prop1.AddAttribute(OpenTap.DisplayAttribute, "Timeout", "VISA Timeout in milliseconds.")

    def Open(self):
        """Called by TAP when the test plan starts."""
        rm = visa.ResourceManager()
        #rm.list_resources()
        self.inst = rm.open_resource(self.visa_address)
        self.inst.timeout = self.Timeout
        self.Info("Funtion Generator connected")
        
    def Close(self):
        """Called by TAP when the test plan ends."""
        if self.inst.open:
            self.inst.close()
            self.Info("Function Generator disconnected")

    
