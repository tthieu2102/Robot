/*
 * Date: 30/10/2015
 * Writer: Loc Pham
 * Description: This file contains function prototypes for keyboard keys
 */

#ifndef _KEYBOARD_H
#define _KEYBOARD_H

// Include header files
#include "stm32f4xx.h"

// Declares macros
#define KEYBOARD_UP 0x0077      // w
#define KEYBOARD_DOWN 0x0073    // s
#define KEYBOARD_LEFT 0x0061    // a
#define KEYBOARD_RIGHT 0x0064   // d
#define KEYBOARD_TERM 0x0030    // 0 

// Struct types
typedef struct 
{
    uint16_t up;
    uint16_t down;
    uint16_t left;
    uint16_t right;
    uint16_t terminator;
} keyboard_t;

#endif
/* End file */
