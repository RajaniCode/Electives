//
//  errors-prefix.pch
//  UsingPhotoModel
//
//  Created by Eric Allam on 2/25/13.
//  Copyright (c) 2013 Code School. All rights reserved.
//

#ifndef UsingPhotoModel_errors_prefix_pch
#define UsingPhotoModel_errors_prefix_pch

#define STRINGIFY2( x) @#x
#define STRINGIFY(x) STRINGIFY2(x)
#define PASTE2( a, b) a#b
#define PASTE( a, b) PASTE2( a, b)

#define ERROR(text) [NSString stringWithFormat:@"%@.%@", STRINGIFY(ERROR_PREFIX), STRINGIFY(text)]
#define ERROR_WITH_ARGUMENTS(text, args) [NSString stringWithFormat:@"%@.%@ --- %@", STRINGIFY(ERROR_PREFIX), STRINGIFY(text), args]

#endif
