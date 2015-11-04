/*
 * Date: 30/10/2015
 * Writter: Loc Pham
 * Description: This file contains function prototypes concerned with on/off button
 */
 
#ifndef _BUTTON_H
#define _BUTTON_H
 
// Include header files
#include "stm32f4xx.h"
#include "stm32f4_discovery.h"

// Macros
#define PRESSED 1u
#define NOT_PRESSED 0u

// Enum types
typedef enum
{
    ButtonOff,
    ButtonOn
} button_mode_e;
 
// Struct types
typedef struct
{
    Button_TypeDef button;
    button_mode_e mode;
} button_t;
 
// PUBLIC function prototypes
/*
 * Name: Button_Init
 * Module: Button
 * Parameters:  None
 * Description: Init button (button_on_off's reference variable won't be changed)
 * Return: void
 */
void Button_Init(button_t* button_on_off);

/*
 * Name: Button_GetMode
 * Module: Button
 * Parameters:  None
 * Description: Get mode of button (On/Off) (button_on_off's reference variable won't be changed)
 * Return: button_mode_e (On/Off)
 */
button_mode_e Button_GetMode(button_t* button_on_off);

/*
 * Name: Button_SetMode
 * Module: Button
 * Parameters:  None
 * Description: Set mode of button (On/Off)
 * Return: void
 */
void Button_SetMode(button_t* button_on_off, button_mode_e mode);

/*
 * Name: Button_PressCheck
 * Module: Button
 * Parameters:  None
 * Description: Listen for pressed event of button
 * Return: void
 */
void Button_PressCheck(button_t* button_on_off);

/*
 * Name: Button_Toggle
 * Module: Button
 * Parameters:  None
 * Description: Toggle button
 * Return: void
 */
void Button_Toggle(button_t* button_on_off);

#endif
/* End file */
