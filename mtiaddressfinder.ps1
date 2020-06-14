$MTI_SIG = "8B 15 ?? ?? ?? ?? 48 63 C2 48 8D 0D ?? ?? ?? ?? FF C2 89 15 ?? ?? ?? ?? 8B 0C 81 8B C1 C1 E8 0B 33 C8 8B C1 25 ?? ?? ?? ?? C1 E0 07 33 C8 8B C1 25 ?? ?? ?? ?? C1 E0 0F 33 C8 8B C1 C1 E8 12 33 C1 48 83 C4 28";
$MTI_OFFSET = 2;

$FFXII_PROCNAME = "FFXII_TZA"

$foundSig = [long]("0x" + (sigscan $FFXII_PROCNAME $MTI_SIG $MTI_OFFSET))
$baseaddress = [long](baseaddress $FFXII_PROCNAME)
$relative = $foundSig - $baseaddress
$moveaddress = [int](memread $FFXII_PROCNAME $foundSig "int")
$mtiaddress = $relative + $moveaddress + 4

Write-Output $mtiaddress.ToString("X4")