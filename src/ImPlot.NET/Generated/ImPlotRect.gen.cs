using System;
using UnityEngine;
using System.Runtime.CompilerServices;
using System.Text;
using ImGuiNET;

namespace ImPlotNET
{
    public unsafe partial struct ImPlotRect
    {
        public ImPlotRange X;
        public ImPlotRange Y;
    }
    public unsafe partial struct ImPlotRectPtr
    {
        public ImPlotRect* NativePtr { get; }
        public ImPlotRectPtr(ImPlotRect* nativePtr) => NativePtr = nativePtr;
        public ImPlotRectPtr(IntPtr nativePtr) => NativePtr = (ImPlotRect*)nativePtr;
        public static implicit operator ImPlotRectPtr(ImPlotRect* nativePtr) => new ImPlotRectPtr(nativePtr);
        public static implicit operator ImPlotRect* (ImPlotRectPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImPlotRectPtr(IntPtr nativePtr) => new ImPlotRectPtr(nativePtr);
        public ref ImPlotRange X => ref Unsafe.AsRef<ImPlotRange>(&NativePtr->X);
        public ref ImPlotRange Y => ref Unsafe.AsRef<ImPlotRange>(&NativePtr->Y);
        public ImPlotPoint Clamp(ImPlotPoint p)
        {
            ImPlotPoint ret = ImPlotNative.ImPlotRect_Clamp_PlotPoint((ImPlotRect*)(NativePtr), p);
            return ret;
        }
        public ImPlotPoint Clamp(double x, double y)
        {
            ImPlotPoint ret = ImPlotNative.ImPlotRect_Clamp_double((ImPlotRect*)(NativePtr), x, y);
            return ret;
        }
        public bool Contains(ImPlotPoint p)
        {
            byte ret = ImPlotNative.ImPlotRect_Contains_PlotPoint((ImPlotRect*)(NativePtr), p);
            return ret != 0;
        }
        public bool Contains(double x, double y)
        {
            byte ret = ImPlotNative.ImPlotRect_Contains_double((ImPlotRect*)(NativePtr), x, y);
            return ret != 0;
        }
        public void Destroy()
        {
            ImPlotNative.ImPlotRect_destroy((ImPlotRect*)(NativePtr));
        }
        public ImPlotPoint Max()
        {
            ImPlotPoint ret = ImPlotNative.ImPlotRect_Max((ImPlotRect*)(NativePtr));
            return ret;
        }
        public ImPlotPoint Min()
        {
            ImPlotPoint ret = ImPlotNative.ImPlotRect_Min((ImPlotRect*)(NativePtr));
            return ret;
        }
        public ImPlotPoint Size()
        {
            ImPlotPoint ret = ImPlotNative.ImPlotRect_Size((ImPlotRect*)(NativePtr));
            return ret;
        }
    }
}
