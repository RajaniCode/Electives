#include <stdio.h>
#include <string.h>

const char* hello_world(char* x, char* y) {  
   static char a[100], b[100];
   strcpy(a, x); 
   strcpy(b, y);
   return strcat(a, b);
}

const char* hello(char* b) {
   static char a[] = "Hello, ";
   return strcat(a, b);
}

int main() {
    printf("%s\n", hello_world("Hello, ", "World!"));
    printf("%s\n", hello("World!"));
}