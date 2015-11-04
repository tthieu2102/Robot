/*
 * Date: 29/10/2015
 * Writter: Loc Pham
 * Description: This file contains function prototypes for controlling motor
 */
 
 /* NOTE: IN THIS VERSION, WE WILL IGNORE SPEED OF MOTOR DUE TO LACK OF KNOWLEDGE ABOUT CREATING PWM SIGNAL */

#ifndef _MOTOR_H
#define _MOTOR_H

// Include header files
#include "stm32f4xx.h"

// Macros

// Enum types
typedef enum
{
    MotorBrake,      // 0 = Brake
    MotorBackward,   // 1 = Clockwise = Backward
    MotorForward,    // 2 = Counter-clockwise = Fordward
} motor_direction_e;

// Struct types
typedef struct
{
    GPIO_TypeDef* gpio_port;
    uint16_t gpio_direction_pin_1;
    uint16_t gpio_direction_pin_2;
    motor_direction_e direction;
    uint16_t speed;
} motor_t;

// PUBLIC FUNCTION PROTOTYPES
/*
 * Name: Motor_Init
 * Module: Motor
 * Parameters:  None
 * Description: Init motor (After done execute function, p_motor's values won't be changed)
 * Return: void
 */
void Motor_Init(motor_t* p_motor);

/*
 * Name: Motor_Init
 * Module: Motor
 * Parameters:  None
 * Description: Brake motor (After done execute function, p_motor's values won't be changed)
 * Return: void
 */
void Motor_Brake(motor_t* p_motor);

/*
 * Name: Motor_MoveForward
 * Module: Motor
 * Parameters:  None
 * Description: Move motor forward (After done execute function, p_motor's values won't be changed)
 * Return: void
 */
void Motor_MoveForward(motor_t* p_motor);

/*
 * Name: Motor_MoveForward
 * Module: Motor
 * Parameters:  None
 * Description: Move motor backward (After done execute function, p_motor's values won't be changed)
 * Return: void
 */
void Motor_MoveBackward(motor_t* p_motor);

/*
 * Name: Motor_Move
 * Module: Motor
 * Parameters:  None
 * Description: Turn motor base on 'direction' attribute (After done execute function, p_motor's values won't be changed)
 * Return: void
 */
void Motor_Move(motor_t* p_motor);

/*
 * Name: Motor_GetDirection
 * Module: Motor
 * Parameters:  None
 * Description: Get motor's direction (After done execute function, p_motor's values won't be changed)
 * Return: motor_direction_e
 */
motor_direction_e Motor_GetDirection(motor_t* p_motor);

/*
 * Name: Motor_SetDirection
 * Module: Motor
 * Parameters:  None
 * Description: Set motor's direction
 * Return: void
 */
void Motor_SetDirection(motor_t* p_motor, motor_direction_e direction);

#endif
// End file
