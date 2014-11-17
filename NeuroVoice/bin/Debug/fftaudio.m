function x = fftaudio(a)
[y Fs]=wavread(a);
ch=chebwin(length(y),50);
vent=y.*ch
yfft=abs(fft(vent));
yfft=abs(yfft(1:length(y)/2));
sum=0;
cont=0;
x=[];
xindex=1;
for i=1:1:length(yfft);
      sum=sum +yfft(i);
      cont=cont+1;
      if cont==246
          sum=sum/246;
          x(xindex)=sum;
          cont=0;
          sum=0;
          xindex=xindex+1;
      end
end

% function x = fftaudio(a)
% [y Fs]=wavread(a);
% yfft=abs(fft(y));
% yfft=abs(yfft(1:length(y)/2));
% sum=0;
% cont=0;
% x=[];
% xindex=1;
% for i=1:1:length(yfft);
%       sum=sum +yfft(i);
%       cont=cont+1;
%       if cont==246
%           sum=sum/246;
%           x(xindex)=sum;
%           cont=0;
%           sum=0;
%           xindex=xindex+1;
%       end
% end

% con 64 se encuentran 62 promedios
% y tomamos una sumatoria cada 62
% y esos serian los patrones "por ahora"