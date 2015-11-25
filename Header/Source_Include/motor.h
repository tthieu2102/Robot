/*
 * Date: 29/10/2015
 * Writter: Loc Pham
 * Description: This file contains function prototypes for controlling motor
 */
 
 /* NOTE: IN THIS VERSION, WE WILL IGNORE SPEED OF MOTOR DUE TO LACK OF KNOWLEDGE ABOUT CREATING PWM SIGNAL */

#ifndef _MOTOR_H
#define _MOTOR_H

// Macros
#define MOTOR_MAX_SPEED              90
#define MOTOR_MIN_SPEED              0
#define MOTOR_SPEED_CHANGE_INTERVAL  10

// Enum types
typedef enum
{
    MotorBrake,      // 0 = Brake
    MotorBackward,   // 1 = Clockwise = Backward
    MotorForward,    // 2 = Counter-clockwise = Fordward
} motor_direction_e;

////22-11-2015 @Hieu
//typedef enum
//{
//    SpeedLevel0 = 0,    // 0%
//    SpeedLevel1 = 25,   // 25%
//    SpeedLevel2 = 50,   // 50%
//    SpeedLevel3 = 75,   // 75%
//    SpeedLevel4 = 100,  // 100%
//} motor_speed_level_e;

// Struct types
typedef struct
{
    GPIO_TypeDef* gpio_port;
    uint16_t gpio_direction_pin_1;
    uint16_t gpio_direction_pin_2;
    motor_direction_e direction;
    TM_PWM_TIM_t tim_data;
    TM_PWM_Channel_t pwm_channel;
    float speed;
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

//22-11-2015 @Hieu
/*
 * Name: Motor_SetSpeedLevel
 * Module: Motor
 * Parameters:  speedPercent: 0-100%
 * Description: Set motor's speed level
 * Return: void
 */
void Motor_SetSpeed(motor_t* p_motor, float speedPercent);

//24-11-2015 @Hieu
/*
 * Name: Motor_ChangeSpeed
 * Module: Motor
 * Parameters:  increase: > 0 to increase speed, <= 0 to decrease speed
 * Description: Change motor's speed up or down
 * Return: void
 */
void Motor_ChangeSpeed(motor_t* p_motor, uint8_t increase);

#endif
// End file
