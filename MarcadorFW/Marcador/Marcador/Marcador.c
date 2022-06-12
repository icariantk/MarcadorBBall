/*
 * Marcador.c
 *
 * Created: 02/06/2012 06:44:54 p.m.
 *  Author: Icarian
 */ 
#include<avr/io.h>
#include<util/delay.h>
#define F_CPU 20000000UL

 
void InitUART( unsigned char baudrate ) {                          //Configurando la UART
UBRRL = baudrate;                                                          //Seleccionando la velocidad

UCSRB = (UCSRB | _BV(RXEN) | _BV(TXEN));                      //Habilitando la transmisión y recepción
}
 
unsigned char ReceiveByte( void ){                                     //Función para recibir un byte
                                     //Esperar la recepción
return UDR;                                                                     //Retornar el dato tomado de la UART
}
 
void TransmitByte( unsigned char data )              {               //Funcion para transmitir dato
while ( !( UCSRA & (1<<UDRE)) );                                      //Esperar transmision completa
UDR = data;                                                                     //Depositar el dato para transmitirlo
}
 
int main (void) {
	int dato;
PORTB=0xFF;  //activar PUllups
DDRB=0xFF;                             //Declarar el registro del puerto D como salidas
PORTB=0xAA;
PORTA=0xFF;  //activar PUllups
DDRA=0xFF;                             //Declarar el registro del puerto D como salidas
PORTA=0x02;
PORTC=0xFF;  //activar PUllups
DDRC=0xFF;                             //Declarar el registro del puerto D como salidas
PORTC=0x01;
 
InitUART( 4 );   
short int numeros[17];
int16_t rotabit[16];
int8_t t=0;
int16_t delay0=0;
int16_t delay1=0;
int16_t delay2=0;

rotabit[0]=0x0001;
rotabit[1]=0x0002;
rotabit[2]=0x0004;
rotabit[3]=0x0008;
rotabit[4]=0x0010;
rotabit[5]=0x0020;
rotabit[6]=0x0040;
rotabit[7]=0x0080;
rotabit[8]=0x0100;
rotabit[9]=0x0200;
rotabit[10]=0x0400;
rotabit[11]=0x0800;
rotabit[12]=0x1000;
rotabit[13]=0x2000;
rotabit[14]=0x4000;
rotabit[15]=0x8000;


for (short int c=0;c!=17;c++){
	numeros[c]=c+1;
	
}                


PORTB=numeros[t];
PORTC=rotabit[t]>>8;
PORTA=rotabit[t]&0x00FF;

while(1){
	delay1++;
	if (numeros[16]==1){
		PORTB=0x0F;
		delay1=0;
		PORTA=1;
		PORTC=0;
		t=0;
	}
	
	
	
	if ( (UCSRA & (1<<RXC)) ){
		dato=ReceiveByte();      
		
		while( !(UCSRA & (1<<RXC)));
		numeros[dato]=ReceiveByte();
		TransmitByte(dato);
	}
	
	if (delay1==10){
		delay2++;
		delay1=0;
	}
	if (delay2==50){
		
		t++;
		if(t==16){t=0;}
		PORTB=numeros[t];
		PORTC=rotabit[t]>>8;
		PORTA=rotabit[t]&0x00FF;
		delay2=0;	
	}
	
	
}
}