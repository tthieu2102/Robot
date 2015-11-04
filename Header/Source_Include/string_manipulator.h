/*
 * Date: 17/10/2015
 * Writter: Loc Pham
 * Description: Declare function prototypes for text processing
 */

#ifndef _STRING_MANIPULATOR_
#define _STRING_MANIPULATOR_

// Include header files
#include "stm32f4xx.h"
#include <string.h>

// PUBLIC FUNCTION PROTOTYPES

/*
 * Name: string_to_uint16_array
 * Module: Led
 * Parameters:  str (char*)
                data (uint16_t*)
                data_length (uint16_t*)
 * Description: Convert from string to uint16 array
 * Return: void
 */
void string_to_uint16_array(char* str, uint16_t* data, uint16_t* data_length);

#endif
/* End file */
