EESchema Schematic File Version 4
EELAYER 30 0
EELAYER END
$Descr A4 11693 8268
encoding utf-8
Sheet 1 1
Title ""
Date ""
Rev ""
Comp ""
Comment1 ""
Comment2 ""
Comment3 ""
Comment4 ""
$EndDescr
$Comp
L Driver_Motor:Pololu_Breakout_DRV8825 A1
U 1 1 629C953B
P 5400 2750
F 0 "A1" H 5400 3531 50  0000 C CNN
F 1 "Pololu DRV8825" H 5400 3440 50  0000 C CNN
F 2 "Module:Pololu_Breakout-16_15.2x20.3mm" H 5600 1950 50  0001 L CNN
F 3 "https://www.pololu.com/product/2982" H 5500 2450 50  0001 C CNN
	1    5400 2750
	1    0    0    -1  
$EndComp
$Comp
L Motor:Stepper_Motor_bipolar M1
U 1 1 629CAB29
P 6550 2950
F 0 "M1" H 6738 3074 50  0000 L CNN
F 1 "17HS4223" H 6738 2983 50  0000 L CNN
F 2 "" H 6560 2940 50  0001 C CNN
F 3 "http://www.infineon.com/dgdl/Application-Note-TLE8110EE_driving_UniPolarStepperMotor_V1.1.pdf?fileId=db3a30431be39b97011be5d0aa0a00b0" H 6560 2940 50  0001 C CNN
	1    6550 2950
	1    0    0    -1  
$EndComp
$Comp
L MCU_Module:WeMos_D1_mini U1
U 1 1 629CDF4F
P 1250 2900
F 0 "U1" H 1250 2011 50  0000 C CNN
F 1 "WeMos_D1_mini" H 1250 1920 50  0000 C CNN
F 2 "Module:WEMOS_D1_mini_light" H 1250 1750 50  0001 C CNN
F 3 "https://wiki.wemos.cc/products:d1:d1_mini#documentation" H -600 1750 50  0001 C CNN
	1    1250 2900
	1    0    0    -1  
$EndComp
Wire Wire Line
	1150 1300 1150 2100
$Comp
L Relay:EC2-12NU K1
U 1 1 629D0E5E
P 3000 2500
F 0 "K1" H 3630 2546 50  0000 L CNN
F 1 "D2n V23105" H 3630 2455 50  0000 L CNN
F 2 "Relay_THT:Relay_DPDT_Kemet_EC2" H 3000 2500 50  0001 C CNN
F 3 "https://content.kemet.com/datasheets/KEM_R7002_EC2_EE2.pdf" H 3000 2500 50  0001 C CNN
	1    3000 2500
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR?
U 1 1 629D4C16
P 2750 4550
F 0 "#PWR?" H 2750 4300 50  0001 C CNN
F 1 "GND" H 2755 4377 50  0000 C CNN
F 2 "" H 2750 4550 50  0001 C CNN
F 3 "" H 2750 4550 50  0001 C CNN
	1    2750 4550
	1    0    0    -1  
$EndComp
$Comp
L power:+5V #PWR?
U 1 1 629D698A
P 2600 950
F 0 "#PWR?" H 2600 800 50  0001 C CNN
F 1 "+5V" H 2615 1123 50  0000 C CNN
F 2 "" H 2600 950 50  0001 C CNN
F 3 "" H 2600 950 50  0001 C CNN
	1    2600 950 
	1    0    0    -1  
$EndComp
Wire Wire Line
	2600 950  2600 1300
Wire Wire Line
	2600 2800 2600 2950
$Comp
L Device:R R1
U 1 1 629EC579
P 1900 3300
F 0 "R1" H 1970 3346 50  0000 L CNN
F 1 "1K" H 1970 3255 50  0000 L CNN
F 2 "" V 1830 3300 50  0001 C CNN
F 3 "~" H 1900 3300 50  0001 C CNN
	1    1900 3300
	0    -1   -1   0   
$EndComp
$Comp
L Device:D D1
U 1 1 629F1547
P 2150 2500
F 0 "D1" H 2150 2717 50  0000 C CNN
F 1 "1N4148" H 2150 2626 50  0000 C CNN
F 2 "" H 2150 2500 50  0001 C CNN
F 3 "~" H 2150 2500 50  0001 C CNN
	1    2150 2500
	0    1    1    0   
$EndComp
Wire Wire Line
	2150 2650 2150 2950
Wire Wire Line
	2150 2950 2600 2950
Wire Wire Line
	2150 2350 2150 2100
Wire Wire Line
	2150 2100 2600 2100
Wire Wire Line
	2600 2100 2600 2200
$Comp
L power:+12V #PWR?
U 1 1 629F3E53
P 5400 950
F 0 "#PWR?" H 5400 800 50  0001 C CNN
F 1 "+12V" H 5415 1123 50  0000 C CNN
F 2 "" H 5400 950 50  0001 C CNN
F 3 "" H 5400 950 50  0001 C CNN
	1    5400 950 
	1    0    0    -1  
$EndComp
Wire Wire Line
	1250 3700 1250 4450
Connection ~ 2750 4450
Wire Wire Line
	2750 4450 2750 4550
Wire Wire Line
	5400 3550 5400 3700
Wire Wire Line
	5500 3550 5500 3700
Wire Wire Line
	5500 3700 5400 3700
Connection ~ 5400 3700
Wire Wire Line
	5400 3700 5400 4450
Wire Wire Line
	5800 3050 6250 3050
Wire Wire Line
	5800 2950 6100 2950
Wire Wire Line
	6100 2950 6100 2850
Wire Wire Line
	6100 2850 6250 2850
Wire Wire Line
	5800 2750 6100 2750
Wire Wire Line
	6100 2750 6100 2650
Wire Wire Line
	6100 2650 6450 2650
Wire Wire Line
	6000 2650 6000 2550
Wire Wire Line
	6000 2550 6650 2550
Wire Wire Line
	6650 2550 6650 2650
Wire Wire Line
	5800 2650 6000 2650
$Comp
L power:AC #PWR?
U 1 1 62A03752
P 4600 900
F 0 "#PWR?" H 4600 800 50  0001 C CNN
F 1 "AC" H 4600 1175 50  0000 C CNN
F 2 "" H 4600 900 50  0001 C CNN
F 3 "" H 4600 900 50  0001 C CNN
	1    4600 900 
	1    0    0    -1  
$EndComp
$Comp
L power:AC #PWR?
U 1 1 62A041A7
P 4850 900
F 0 "#PWR?" H 4850 800 50  0001 C CNN
F 1 "AC" H 4850 1175 50  0000 C CNN
F 2 "" H 4850 900 50  0001 C CNN
F 3 "" H 4850 900 50  0001 C CNN
	1    4850 900 
	1    0    0    -1  
$EndComp
$Comp
L power:AC #PWR?
U 1 1 62A05031
P 3600 900
F 0 "#PWR?" H 3600 800 50  0001 C CNN
F 1 "AC" H 3600 1175 50  0000 C CNN
F 2 "" H 3600 900 50  0001 C CNN
F 3 "" H 3600 900 50  0001 C CNN
	1    3600 900 
	1    0    0    -1  
$EndComp
$Comp
L power:AC #PWR?
U 1 1 62A05B65
P 3850 900
F 0 "#PWR?" H 3850 800 50  0001 C CNN
F 1 "AC" H 3850 1175 50  0000 C CNN
F 2 "" H 3850 900 50  0001 C CNN
F 3 "" H 3850 900 50  0001 C CNN
	1    3850 900 
	1    0    0    -1  
$EndComp
Wire Wire Line
	2750 4450 4300 4450
Text GLabel 4900 2750 0    50   Input ~ 0
~EN
Wire Wire Line
	4900 2750 5000 2750
Text GLabel 4900 2850 0    50   Input ~ 0
STEP
Text GLabel 4900 2950 0    50   Input ~ 0
DIR
Wire Wire Line
	4900 2850 5000 2850
Wire Wire Line
	4900 2950 5000 2950
$Comp
L Switch:SW_DIP_x03 SW1
U 1 1 629D69E3
P 4500 3750
F 0 "SW1" V 4546 3620 50  0000 R CNN
F 1 "SW_DIP_x03" V 4455 3620 50  0000 R CNN
F 2 "" H 4500 3750 50  0001 C CNN
F 3 "~" H 4500 3750 50  0001 C CNN
	1    4500 3750
	0    -1   -1   0   
$EndComp
$Comp
L Device:R R?
U 1 1 629DB1E7
P 4300 2400
F 0 "R?" H 4370 2446 50  0000 L CNN
F 1 "2K2" H 4370 2355 50  0000 L CNN
F 2 "" V 4230 2400 50  0001 C CNN
F 3 "~" H 4300 2400 50  0001 C CNN
	1    4300 2400
	1    0    0    -1  
$EndComp
Wire Wire Line
	4300 4050 4300 4450
Connection ~ 4300 4450
Wire Wire Line
	4300 4450 5400 4450
Connection ~ 4300 4050
Wire Wire Line
	4300 4050 4400 4050
Connection ~ 4400 4050
Wire Wire Line
	4400 4050 4500 4050
Text GLabel 3550 1000 0    50   Output ~ 0
ACPHASEIN
Text GLabel 3650 1150 0    50   Output ~ 0
ACNEUTRALIN
Wire Wire Line
	3600 900  3600 1000
Wire Wire Line
	3850 900  3850 1150
Text GLabel 4550 1000 0    50   Input ~ 0
ACPHASEOUT
Text GLabel 4650 1150 0    50   Input ~ 0
ACNEUTRALOUT
Wire Wire Line
	4600 900  4600 1000
Wire Wire Line
	4850 900  4850 1150
Wire Wire Line
	2600 2950 2600 3100
Connection ~ 2600 2950
Wire Wire Line
	1650 3300 1750 3300
Wire Wire Line
	2600 3500 2600 4450
Connection ~ 2600 4450
Wire Wire Line
	2600 4450 2750 4450
Wire Wire Line
	4600 1000 4550 1000
Wire Wire Line
	4650 1150 4850 1150
Wire Wire Line
	3550 1000 3600 1000
Wire Wire Line
	3650 1150 3850 1150
Text GLabel 3000 2900 3    50   Input ~ 0
ACPHASEIN
Text GLabel 3400 2900 3    50   Input ~ 0
ACNEUTRALIN
Wire Wire Line
	3000 2900 3000 2800
Wire Wire Line
	3400 2900 3400 2800
Text GLabel 3100 2100 1    50   Output ~ 0
ACPHASEOUT
Text GLabel 3500 2100 1    50   Output ~ 0
ACNEUTRALOUT
Wire Wire Line
	3100 2200 3100 2100
Wire Wire Line
	3500 2200 3500 2100
NoConn ~ 700  2500
Wire Wire Line
	700  2500 850  2500
NoConn ~ 700  2800
NoConn ~ 700  2900
Wire Wire Line
	700  2800 850  2800
Wire Wire Line
	700  2900 850  2900
NoConn ~ 1350 1950
Wire Wire Line
	1350 1950 1350 2100
$Comp
L Transistor_BJT:2N2219 Q?
U 1 1 629D947C
P 2500 3300
F 0 "Q?" H 2690 3346 50  0000 L CNN
F 1 "2N2219" H 2690 3255 50  0000 L CNN
F 2 "Package_TO_SOT_THT:TO-39-3" H 2700 3225 50  0001 L CIN
F 3 "http://www.onsemi.com/pub_link/Collateral/2N2219-D.PDF" H 2500 3300 50  0001 L CNN
	1    2500 3300
	1    0    0    -1  
$EndComp
Wire Wire Line
	1250 4450 2600 4450
Wire Wire Line
	2050 3300 2300 3300
$Comp
L Device:R R?
U 1 1 62AAD9D7
P 4400 2650
F 0 "R?" H 4470 2696 50  0000 L CNN
F 1 "2K2" H 4470 2605 50  0000 L CNN
F 2 "" V 4330 2650 50  0001 C CNN
F 3 "~" H 4400 2650 50  0001 C CNN
	1    4400 2650
	1    0    0    -1  
$EndComp
$Comp
L Device:R R?
U 1 1 62AAF650
P 4500 2900
F 0 "R?" H 4570 2946 50  0000 L CNN
F 1 "2K2" H 4570 2855 50  0000 L CNN
F 2 "" V 4430 2900 50  0001 C CNN
F 3 "~" H 4500 2900 50  0001 C CNN
	1    4500 2900
	1    0    0    -1  
$EndComp
Wire Wire Line
	4500 3050 4500 3150
Wire Wire Line
	4400 2800 4400 3250
Wire Wire Line
	4300 2550 4300 3350
Wire Wire Line
	5000 3150 4500 3150
Connection ~ 4500 3150
Wire Wire Line
	4500 3150 4500 3450
Wire Wire Line
	4950 3250 4400 3250
Connection ~ 4400 3250
Wire Wire Line
	4400 3250 4400 3450
Wire Wire Line
	5000 3350 4300 3350
Connection ~ 4300 3350
Wire Wire Line
	4300 3350 4300 3450
Wire Wire Line
	4400 2500 4400 2200
Wire Wire Line
	4400 2200 4300 2200
Wire Wire Line
	4300 2200 4300 2250
Wire Wire Line
	4500 2750 4500 2200
Wire Wire Line
	4500 2200 4400 2200
Connection ~ 4400 2200
Wire Wire Line
	5400 950  5400 2150
Wire Wire Line
	2600 1300 2600 2100
Connection ~ 2600 2100
Connection ~ 2600 1300
Wire Wire Line
	1150 1300 2600 1300
Wire Wire Line
	4400 2200 4400 1300
Wire Wire Line
	4400 1300 2600 1300
$EndSCHEMATC
