# AuroraLib.Compression-cli
A simple command line interface for [AuroraLib.Compression](https://github.com/Venomalia/AuroraLib.Compression) library to operate it as a standalone program.

## Usage
```
AuroraLibCompression-cli.exe -c|-d <algorithm> <inputFile> <outputFile>
```

`-c` argument is for compression, `-d` is for decompression.

Full list of supported algoritms: LZ10, LZ11, LZ40, LZ60, LZ77, MIO0, Yay0, Yaz0, Yaz1, HUF20, RLE30, LZOn, HWGZ, PRS, LZSega, CNX2, COMP, CXLZ, LZ00, LZ01, AKLZ, CNS, CLZ0, FCMP, GCLZ, LZ02, LZHudson, RLHudson, LZShrek, LZSS, RefPack, GZip, ZLib, AsuraZlb, ZLB, ALLZ, LZO, LZ4, MDF0, Level5, SSZL, IECP

Usage example:
```
AuroraLibCompression-cli -d allz INPUT.dat OUTPUT.dat
```

## Notes

- I'm not sure how to switch the endianess of the algroithms that have big endian and little endian versions (MIO0, Yay0, Yaz0, Yaz1, PRS), so your milage may wary with using those.
