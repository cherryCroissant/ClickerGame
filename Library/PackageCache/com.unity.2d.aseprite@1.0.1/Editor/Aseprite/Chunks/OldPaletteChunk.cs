using System.IO;

namespace UnityEditor.U2D.Aseprite
{
    /// <summary>
    /// Parsed representation of an Aseprite Old Palette chunk.
    /// </summary>
    /// <note>Not supported yet.</note>
    internal class OldPaletteChunk : BaseChunk
    {
        public override ChunkTypes chunkType => ChunkTypes.OldPalette;
        
        internal OldPaletteChunk(uint chunkSize) : base(chunkSize) { }
        protected override void InternalRead(BinaryReader reader) { }
    }
}