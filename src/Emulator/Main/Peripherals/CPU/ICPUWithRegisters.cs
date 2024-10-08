//
// Copyright (c) 2010-2024 Antmicro
//
// This file is licensed under the MIT License.
// Full license text is available in 'licenses/MIT.txt'.
//

using System;
using Antmicro.Renode.Core;
using Antmicro.Renode.Peripherals.Bus;
using Antmicro.Renode.Time;
using Antmicro.Renode.Utilities;
using System.Collections.Generic;

namespace Antmicro.Renode.Peripherals.CPU
{
    public interface ICPUWithRegisters : ICPU
    {
        void SetRegister(int register, RegisterValue value);
        RegisterValue GetRegister(int register);
        void SetRegisterUnsafe(int register, RegisterValue value);
        RegisterValue GetRegisterUnsafe(int register);
        IEnumerable<CPURegister> GetRegisters();
        string[,] GetRegistersValues();
    }

    public static class ICPUWithRegistersExtensions
    {
        // this is to support Python integration
        public static void SetRegisterUlong(this ICPUWithRegisters cpu, int register, ulong value)
        {
            cpu.SetRegister(register, value);
        }
    }
}

