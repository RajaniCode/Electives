#include <stdio.h>
#include <string.h>

int main() {

    int var, *ptr1, **ptr2;
  
    var = 555;
    printf("value of var = %d\n\n", var); // 555

    // assign address of variable
    ptr1 = &var;
    printf("address of var: &var = %p\n", &var); // #
    printf("pointer to var: (ptr1 = &var) = %p\n", ptr1); // #
    printf("dereference the address of pointer to var: *&ptr1 = %p\n\n", *&ptr1); // #

    printf("dereference the address of var: *&var = %d\n", *&var); // 555
    printf("dereference twice the address of pointer to var: **&ptr1 = %d\n\n", **&ptr1); // 555

    printf("address of pointer to pointer: &ptr1 = %p\n", &ptr1); // $
    // assign address of pointer
    ptr2 = &ptr1;
    printf("address of pointer to pointer: (ptr2 = &ptr1) = %p\n", ptr2); // $
    printf("dereference the address of pointer to pointer: *&ptr2 = %p\n\n", *&ptr2); // $

    printf("dereference twice the address of pointer to pointer: **&ptr2 = %p\n\n", **&ptr2); // #

    printf("dereference thrice the address of pointer to pointer: ***&ptr2 = %d\n", ***&ptr2); // 555

    // assign pointer
    // error: incompatible integer to pointer conversion assigning to 'int *' from 'int'; remove *
    // ptr1 = *&var;

    // assign address of var
    ptr1 = &var;

    // assign address of pointer
    ptr2 = &ptr1;

    // assign pointer
    // error: incompatible pointer types assigning to 'int **' from 'int *'; take the address with &
    // ptr2 = ptr1;

    // assign pointer to pointer
    // error: incompatible pointer types assigning to 'int *' from 'int **'; dereference with *
    // ptr1 = ptr2;
}

/*
// "_main"
gcc mnemonics.cc -o mnemonics
./mnemonics

$ gcc -c mnemonics.cc

$ gcc -shared -o mmnemonics.dll mnemonics.o

% gcc -c -fPIC mnemonics.cc

% gcc -shared -o mnemonics.so mnemonics.o
*/