/*
 * Date: 17/10/2015
 * Writter: Loc Pham
 * Description: Implement function prototypes
 */

#include "string_manipulator.h"

void string_to_uint16_array(char* str, uint16_t* data, uint16_t* data_length)
{
    uint16_t counter = 0;
    if (str != 0 && data != 0 && data_length != 0)
    {
        *data_length = (uint16_t) strlen(str);
        memset(data, 0, *data_length);
        
        for (; counter < *data_length; counter++)
        {
            data[counter] = (uint16_t) str[counter];
        }
    }
}
/* End file */
