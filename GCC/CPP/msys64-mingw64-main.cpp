#include <stdio.h>
#include <string.h>

extern "C" {
    __declspec(dllexport) const char* hello_world(char* x, char* y) {  
        static char a[100], b[100];
        strcpy(a, x); 
        strcpy(b, y);
        return strcat(a, b);
    }

    __declspec(dllexport) const char* hello(char *b) {
       static char a[] = "Hello, ";
       return strcat(a, b);
    }    
}

int main() {
    printf("%s\n", hello_world((char*)"Hello, ", (char*)"World!"));
    printf("%s\n", hello((char*)"World!"));
}