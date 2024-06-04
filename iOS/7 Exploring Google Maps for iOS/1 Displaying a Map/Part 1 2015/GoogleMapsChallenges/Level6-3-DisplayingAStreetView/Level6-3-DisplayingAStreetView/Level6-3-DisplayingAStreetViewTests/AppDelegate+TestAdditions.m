#import "AppDelegate+TestAdditions.h"
#import <objc/objc-runtime.h>

@implementation AppDelegate (TestAdditions)

- (void)setMarkers:(GMSCameraPosition *)markers
{
    objc_setAssociatedObject(self, @selector(markers), markers, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)markers
{
    return objc_getAssociatedObject(self, @selector(markers));
}

- (void)setPanorama:(GMSPanorama *)panorama
{
  objc_setAssociatedObject(self, @selector(panorama), panorama, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (GMSPanorama *)panorama
{
  return objc_getAssociatedObject(self, @selector(panorama));
}

- (void)setCamera:(GMSPanoramaCamera *)camera
{
  objc_setAssociatedObject(self, @selector(camera), camera, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (GMSPanoramaCamera *)camera
{
  return objc_getAssociatedObject(self, @selector(camera));
}

- (void)setPanoramaView:(GMSPanoramaView *)panoramaView
{
  objc_setAssociatedObject(self, @selector(panoramaView), panoramaView, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (GMSPanoramaView *)panoramaView
{
  return objc_getAssociatedObject(self, @selector(panoramaView));
}

@end
