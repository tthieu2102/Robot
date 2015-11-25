/*
 * Date: 11/10/2015
 * Writer: Loc Pham
 * Description: Contains system prototypes
 */
 
#ifndef _MAIN_H
#define _MAIN_H

// PUBLIC PROTOTYPE FUNCTIONS
void LeftMotor_Configure(motor_t* p_motor);
void RightMotor_Configure(motor_t* p_motor);
void OnOffButton_Configure(button_t* p_button);
void UARTReceiver_Configure(usart_t* p_controller);
void Keyboard_Configure(keyboard_t* p_keyboard);

#endif
/*End file*/
