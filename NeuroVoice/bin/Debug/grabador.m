function varargout = grabador(varargin)
% GRABADOR MATLAB code for grabador.fig
%      GRABADOR, by itself, creates a new GRABADOR or raises the existing
%      singleton*.
%
%      H = GRABADOR returns the handle to a new GRABADOR or the handle to
%      the existing singleton*.
%
%      GRABADOR('CALLBACK',hObject,eventData,handles,...) calls the local
%      function named CALLBACK in GRABADOR.M with the given input arguments.
%
%      GRABADOR('Property','Value',...) creates a new GRABADOR or raises the
%      existing singleton*.  Starting from the left, property value pairs are
%      applied to the GUI before grabador_OpeningFcn gets called.  An
%      unrecognized property name or invalid value makes property application
%      stop.  All inputs are passed to grabador_OpeningFcn via varargin.
%
%      *See GUI Options on GUIDE's Tools menu.  Choose "GUI allows only one
%      instance to run (singleton)".
%
% See also: GUIDE, GUIDATA, GUIHANDLES

% Edit the above text to modify the response to help grabador

% Last Modified by GUIDE v2.5 15-Nov-2014 13:09:23

% Begin initialization code - DO NOT EDIT
gui_Singleton = 1;
gui_State = struct('gui_Name',       mfilename, ...
                   'gui_Singleton',  gui_Singleton, ...
                   'gui_OpeningFcn', @grabador_OpeningFcn, ...
                   'gui_OutputFcn',  @grabador_OutputFcn, ...
                   'gui_LayoutFcn',  [] , ...
                   'gui_Callback',   []);
if nargin && ischar(varargin{1})
    gui_State.gui_Callback = str2func(varargin{1});
end

if nargout
    [varargout{1:nargout}] = gui_mainfcn(gui_State, varargin{:});
else
    gui_mainfcn(gui_State, varargin{:});
end
% End initialization code - DO NOT EDIT


% --- Executes just before grabador is made visible.
function grabador_OpeningFcn(hObject, eventdata, handles, varargin)
% This function has no output args, see OutputFcn.
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
% varargin   command line arguments to grabador (see VARARGIN)

% Choose default command line output for grabador
handles.output = hObject;

% Update handles structure
guidata(hObject, handles);

% UIWAIT makes grabador wait for user response (see UIRESUME)
% uiwait(handles.figure1);


% --- Outputs from this function are returned to the command line.
function varargout = grabador_OutputFcn(hObject, eventdata, handles) 
% varargout  cell array for returning output args (see VARARGOUT);
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Get default command line output from handles structure
varargout{1} = handles.output;


% --- Executes on button press in PB_Grabar.
function PB_Grabar_Callback(hObject, eventdata, handles)
% hObject    handle to PB_Grabar (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
g=audiorecorder;
record(g);
pause(1);
stop(g);
y=getaudiodata(g);
Fs=g.SampleRate;
iletra=get(handles.CB_Letra,'string');
letra=iletra{get(handles.CB_Letra,'value')};
ipersona=get(handles.CB_Persona,'string');
persona=ipersona{get(handles.CB_Persona,'value')};
wavwrite(y,Fs,strcat(letra,persona));


% --- Executes on selection change in CB_Letra.
function CB_Letra_Callback(hObject, eventdata, handles)
% hObject    handle to CB_Letra (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: contents = cellstr(get(hObject,'String')) returns CB_Letra contents as cell array
%        contents{get(hObject,'Value')} returns selected item from CB_Letra


% --- Executes during object creation, after setting all properties.
function CB_Letra_CreateFcn(hObject, eventdata, handles)
% hObject    handle to CB_Letra (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: popupmenu controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end


% --- Executes on selection change in CB_Persona.
function CB_Persona_Callback(hObject, eventdata, handles)
% hObject    handle to CB_Persona (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: contents = cellstr(get(hObject,'String')) returns CB_Persona contents as cell array
%        contents{get(hObject,'Value')} returns selected item from CB_Persona


% --- Executes during object creation, after setting all properties.
function CB_Persona_CreateFcn(hObject, eventdata, handles)
% hObject    handle to CB_Persona (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: popupmenu controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end
