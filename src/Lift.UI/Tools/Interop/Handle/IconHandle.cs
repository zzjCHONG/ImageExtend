﻿using System;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace Lift.UI.Tools.Interop;

public sealed class IconHandle : WpfSafeHandle
{
    [SecurityCritical]
    private IconHandle() : base(true, CommonHandles.Icon)
    {
    }

    [SecurityCritical]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    protected override bool ReleaseHandle()
    {
        return InteropMethods.DestroyIcon(handle);
    }

    [SecurityCritical, SecuritySafeCritical]
    internal static IconHandle GetInvalidIcon()
    {
        return new();
    }

    [SecurityCritical]
    internal IntPtr CriticalGetHandle()
    {
        return handle;
    }
}
