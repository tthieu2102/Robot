/*
 * Date: 30/11/2015
 * Writer: Loc Pham
 * Desciption: This file contains function implementations concerned with controlling on/off button
 */

#include "button.h"
#include <stdio.h>
#include "stm32f4_discovery.h"

button_mode_e Button_GetMode(button_t* button_on_off)
{
    button_mode_e result = ButtonOff;
    
    if (button_on_off != NULL)
    {
        result = button_on_off->mode;
    }
    
    return result;
}

void Button_SetMode(button_t* button_on_off, button_mode_e mode)
{
    if (button_on_off != NULL)
    {
        button_on_off->mode = mode;
    }
}

void Button_PressCheck(button_t* button_on_off)
{
    if (button_on_off != NULL)
    {
        // Check button pressed
        if (STM_EVAL_PBGetState(button_on_off->button) == Bit_SET)
        {
            // Change mode
            Button_Toggle(button_on_off);
        }
    }
}

void Button_Toggle(button_t* button_on_off)
{
    if (button_on_off != NULL)
    {
        button_mode_e mode = Button_GetMode(button_on_off);
        switch (mode)
        {
            case ButtonOn:
                Button_SetMode(button_on_off, ButtonOff);
                break;
            case ButtonOff:
                Button_SetMode(button_on_off, ButtonOn);
                break;
            default:
                // Do nothing
                break;
        }
    }
}

void Button_Init(button_t* button_on_off)
{
    STM_EVAL_PBInit(button_on_off->button, BUTTON_MODE_GPIO);
}

/* End file */
