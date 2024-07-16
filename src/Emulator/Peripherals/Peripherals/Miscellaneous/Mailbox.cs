using System;
using System.Threading;
using Antmicro.Renode;
using Antmicro.Renode.Core;
using Antmicro.Renode.Logging;
using Antmicro.Renode.Peripherals.Bus;

namespace Antmicro.Renode.Peripherals.Miscellaneous
{
    public class Mailbox: IDoubleWordPeripheral, IKnownSize
    {
        public Mailbox(IMachine machine)
        {
            this.machine = machine;
        }
            
        public long Size => 0x100;

        public void Reset() {}

        public uint ReadDoubleWord(long offset)
        {
            this.Log(LogLevel.Warning, "Unhandled read to Mailbox: offset={0} value={1}", offset);
            return 0;
        }

        public void WriteDoubleWord(long offset, uint value)
        {
            if((Register)offset == Register.Shutdown)
            {
                this.Log(LogLevel.Info, "Emulator shutdown requested by software");
                Thread.Sleep(5000);
                Emulator.Exit();
            }
            else
            {
                this.Log(LogLevel.Warning, "Unhandled write to Mailbox: offset={0} value={1}", offset, value);
            }
        }

        private readonly IMachine machine;

        private enum Register : uint
        {
            Shutdown = 0xFC
        }
    }
}