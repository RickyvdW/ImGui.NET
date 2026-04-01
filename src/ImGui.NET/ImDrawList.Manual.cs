using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace ImGuiNET
{
    public unsafe partial struct ImDrawListPtr
    {
        // public static extern void ImDrawList_AddText_Vec2(ImDrawList* self, Vector2 pos, uint col, byte* text_begin, byte* text_end);
        // [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public void AddText(Vector2 pos, uint col, string fmt)
        {
            byte* native_fmt;
            int fmt_byteCount = 0;
            if (fmt != null)
            {
                fmt_byteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmt_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_fmt = Util.Allocate(fmt_byteCount + 1);
                }
                else
                {
                    byte* native_fmt_stackBytes = stackalloc byte[fmt_byteCount + 1];
                    native_fmt = native_fmt_stackBytes;
                }
                int native_fmt_offset = Util.GetUtf8(fmt, native_fmt, fmt_byteCount);
                native_fmt[native_fmt_offset] = 0;
            }
            else { native_fmt = null; }
            ImGuiNative.ImDrawList_AddText_Vec2((ImDrawList*)(NativePtr), pos, col, native_fmt, native_fmt + fmt_byteCount);
            if (fmt_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_fmt);
            }
        }
    }
}