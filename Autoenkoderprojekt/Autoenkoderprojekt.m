divfac = 10;

image=im2double(imread('sampleimage.bmp'));
imdim=zeros(1:2);
imdim(1)=size(image,1);
imdim(2)=size(image,2);
cells1=floor(imdim(1)/divfac);
cells2=floor(imdim(2)/divfac);

chopped = cell(cells1,cells2);

for x = 1:(cells1)
    for y = 1:(cells2)
        chopped{x,y} = image((x-1)*divfac+1:x*divfac,(y-1)*divfac+1:y*divfac,1:3);
    end
end

figure(1);
imshow(cell2mat(chopped));

imagecell = {image};

aec = trainAutoencoder(chopped,10,'MaxEpochs',1200,'UseGPU',true);

encodeddata = encode(aec,chopped);
decodeddata = decode(aec,encodeddata);

decodedchopped = reshape(decodeddata,[cells1,cells2]);

decodedsharpened = cell(cells1,cells2);

sharpen = 1; %kontrola filtru - wy³¹czany dla celów testowych

if(sharpen==1)
    parfor x = 1:(cells1)
        for y = 1:(cells2)
            decodedsharpened{x,y} = imsharpen(decodedchopped{x,y},'Amount',1,'Radius',3);
        end
    end
end

figure(2);
imshow(cell2mat(decodedchopped));

figure(3);
imshow(imgaussfilt(cell2mat(decodedchopped)));

if(sharpen==1)
    figure(5);
    imshow(imgaussfilt(cell2mat(decodedsharpened)));
end


