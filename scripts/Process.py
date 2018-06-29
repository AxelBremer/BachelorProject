from PIL import Image
import os

# This function changes the contrast of an image to a given level.
# source: https://stackoverflow.com/questions
#                         /42045362/change-contrast-of-image-in-pil
def change_contrast(img, level):
    factor = (259 * (level + 255)) / (255 * (259 - level))
    def contrast(c):
        return 128 + factor * (c - 128)
    return img.point(contrast)

# This function checks if the objects in a given list are complete.
# If not, the object and the type of file it does have are added to the dict
def check_list(toCheck, type):
    checked = [i for i in toCheck if not ((i in bookimagelist) and (i in diffuselist) and (i in normallist) and (i in modellist) )]
    if len(checked) > 0:
        for object in checked:
            if object not in missingdict: missingdict[object] = []
            missingdict[object].append(type)

# This Function prints all the incomplete objects and also prints the files
# they are missing.
def print_incomplete(dict):
    print("All objects should have a model, a book image, a normal texture and a diffuse texture.")
    print("The following objects are not complete and need to be fixed:\n")

    for objectName, itemsItHas in dict.items():
        newList = [i for i in itemlist if i not in itemsItHas]
        string = "is missing: "
        for item in newList:
            string += "a " + item + " and "
        string = string[:-5]
        print("\t", objectName, string, "\n")

# Create lists of all the files in the images, textures and models folders
itemlist = ['normal texture', 'diffuse texture', 'book image', 'model']
bookimagelist = os.listdir('../book-images')
texturelist = os.listdir('../MuseumTextures')
modellist = os.listdir('../MuseumModels')
diffuselist = []
normallist = []
temp = []
missingdict = {}

# Raise the contrast of each book image to 60 and save it in the marker folder
for filename in bookimagelist:
    im = Image.open("book-images/" + filename)
    im = change_contrast(im, 60)
    im.save("marker-images/" + filename)

# Divide the textures in a normal texture list and diffuse texture list
for filename in texturelist:
    if filename.endswith('diffuse.jpg'):
        diffuselist.append(filename[:-12])
    if filename.endswith('normal.jpg'):
        normallist.append(filename[:-11])

# Remove the extension as with all the other filenames
for filename in modellist:
    filename = filename[:-4]
    temp.append(filename)

modellist = temp
temp = []

# Remove the extension as with all the other filenames
for filename in bookimagelist:
    filename = filename[:-4]
    temp.append(filename)

bookimagelist = temp

# Check all the lists
check_list(normallist, "normal texture")
check_list(diffuselist, "diffuse texture")
check_list(bookimagelist, "book image")
check_list(modellist, "model")

# Print the incomplete objects
print_incomplete(missingdict)
