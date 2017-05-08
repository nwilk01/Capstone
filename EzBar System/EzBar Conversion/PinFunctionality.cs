/************************************************************************************************
/ Evan Mladinov                                                                                 /
/ 4/26/2017                                                                                     /
/ This code is to initial the pins on a Raspberry Pi 3. Along with the initialization are       /
/ functions that turn on the pins when called for a time that is passed into them               /
************************************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaspberryPiDotNet;

namespace EzBar_Conversion
{
    class PinFunctionality
    {
        public static GPIOMem local1;
        public static GPIOMem local2;
        public static GPIOMem local3;
        public static GPIOMem local4;
        public static GPIOMem local5;
        public static GPIOMem local6;
        public static GPIOMem local7;
        public static GPIOMem local8;
        public static GPIOMem local9;
        public static GPIOMem local10;

        // Initializes the variables to pins 
        public static void initalizepins()
        {
            local1 = new GPIOMem(GPIOPins.V2_GPIO_03); // Pin 3 
            local2 = new GPIOMem(GPIOPins.V2_GPIO_04); // Pin 4
            local3 = new GPIOMem(GPIOPins.V2_GPIO_07); // Pin 7
            local4 = new GPIOMem(GPIOPins.V2_GPIO_08); // Pin 8
            local5 = new GPIOMem(GPIOPins.V2_GPIO_09); // Pin 9
            local6 = new GPIOMem(GPIOPins.V2_GPIO_10); // Pin 10
            local7 = new GPIOMem(GPIOPins.V2_GPIO_11); // Pin 11
            local8 = new GPIOMem(GPIOPins.V2_GPIO_14); // Pin 14
            local9 =  new GPIOMem(GPIOPins.V2_GPIO_02); // Pin 2
            local10 = new GPIOMem(GPIOPins.V2_GPIO_15); // Pin 15
        }

        // The following ten functions enable a pin to high then a delay for the time passed in.
        // After the delay has expired the pin is set to low.
        public static void pos1(int time)
        {
            local1.Write(PinState.High);
            System.Threading.Thread.Sleep(time);
            local1.Write(PinState.Low);
        }
        public static void pos2(int time)
        {
            local2.Write(PinState.High);
            System.Threading.Thread.Sleep(time);
            local2.Write(PinState.Low);
        }
        public static void pos3(int time)
        {
            local3.Write(PinState.High);
            System.Threading.Thread.Sleep(time);
            local3.Write(PinState.Low);
        }
        public static void pos4(int time)
        {
            local4.Write(PinState.High);
            System.Threading.Thread.Sleep(time);
            local4.Write(PinState.Low);
        }
        public static void pos5(int time)
        {
            local5.Write(PinState.High);
            System.Threading.Thread.Sleep(time);
            local5.Write(PinState.Low);
        }
        public static void pos6(int time)
        {
            local6.Write(PinState.High);
            System.Threading.Thread.Sleep(time);
            local6.Write(PinState.Low);
        }
        public static void pos7(int time)
        {
            local7.Write(PinState.High);
            System.Threading.Thread.Sleep(time);
            local7.Write(PinState.Low);
        }
        public static void pos8(int time)
        {
            local8.Write(PinState.High);
            System.Threading.Thread.Sleep(time);
            local8.Write(PinState.Low);
        }
        public static void pos9(int time)
        {
            local9.Write(PinState.High);
            System.Threading.Thread.Sleep(time);
            local9.Write(PinState.Low);
        }
        public static void pos10(int time)
        {
            local10.Write(PinState.High);
            System.Threading.Thread.Sleep(time);
            local10.Write(PinState.Low);
        }
    }
}
