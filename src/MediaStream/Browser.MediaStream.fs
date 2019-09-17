namespace Browser.Types

open System
open Fable.Core
open Browser
open Browser.Types


type MediaTrackSupportedConstraints =
    abstract autoGainControl:bool option with get, set
    abstract width:bool option with get, set
    abstract height:bool option with get, set
    abstract aspectRatio:bool option with get, set
    abstract frameRate:bool option with get, set
    abstract facingMode:bool option with get, set
    abstract resizeMode:bool option with get, set
    abstract volume:bool option with get, set
    abstract sampleRate:bool option with get, set
    abstract sampleSize:bool option with get, set
    abstract echoCancellation:bool option with get, set
    abstract latency:bool option with get, set
    abstract noiseSuppression:bool option with get, set
    abstract channelCount:bool option with get, set
    abstract deviceId:bool option with get, set
    abstract groupId:bool option with get, set

type Range<'T> =
    abstract max: 'T option with get, set
    abstract min: 'T option with get, set

type ULongRange = Range<uint32>
type DoubleRange = Range<float>

type ConstrainRange<'T> =
    inherit Range<'T>
    abstract exact: 'T option with get, set
    abstract ideal: 'T option with get, set

type Constrain<'T> =
    abstract exact: 'T option with get, set
    abstract ideal: 'T option with get, set

[<Erase>]
type ConstrainOrRange<'T> =
    | Value of 'T
    | ConstrainRange of ConstrainRange<'T>

type ConstrainOrRangeULong = ConstrainOrRange<uint32>
type ConstrainOrRangeDouble = ConstrainOrRange<float>

type ConstrainULong = Constrain<uint32>
type ConstrainDouble = Constrain<float>
type ConstrainString = Constrain<string>
type ConstrainBoolean = Constrain<bool>


type MediaTrackConstraintSet =
    abstract deviceId: ConstrainString option with get, set
    abstract groupId: ConstrainString option with get, set

type MediaTrackSettings =
    abstract deviceId: string
    abstract groupId: string

type AudioConstraint =
    inherit MediaTrackConstraintSet
    abstract autoGainControl: ConstrainBoolean option with get, set
    abstract channelCount: ConstrainOrRangeULong option with get, set
    abstract echoCancellation: ConstrainBoolean option with get, set
    abstract latency: ConstrainOrRangeDouble option with get, set
    abstract noiseSuppression: ConstrainBoolean option with get, set
    abstract sampleRate: ConstrainOrRangeULong option with get, set
    abstract sampleSize: ConstrainOrRangeULong option with get, set
    abstract volume: ConstrainOrRangeDouble option with get, set

type AudioMediaTrackSettings =
    inherit MediaTrackSettings
    abstract autoGainControl: bool
    abstract channelCount: uint32
    abstract echoCancellation: bool
    abstract latency: double
    abstract noiseSuppression: bool
    abstract sampleRate: uint32
    abstract sampleSize: uint32
    abstract volume: double

[<StringEnum>]
type ShotMode =
    | [<CompiledName("none")>] None'
    | Manual
    | [<CompiledName("single-shot")>] SingleShot
    | Continuous

type ConstrainShotMode = Constrain<ShotMode>

type PointsOfInterest =
    abstract x:uint32 with get, set
    abstract y:uint32 with get, set

[<Erase>]
type PointsOfInterestConstraint =
    | Point of PointsOfInterest
    | Points of ResizeArray<PointsOfInterest>

type ImageMediaTrackConstraintSet =
    inherit MediaTrackConstraintSet
    abstract whiteBalanceMode: ConstrainShotMode option with get, set
    abstract exposureMode: ConstrainShotMode option with get, set
    abstract focusMode: ConstrainShotMode option with get, set
    abstract pointsOfInterest: PointsOfInterestConstraint option with get, set
    abstract exposureCompensation: ConstrainDouble option with get, set
    abstract colorTemperature: ConstrainDouble option with get, set
    abstract iso: ConstrainDouble option with get, set
    abstract brightness: ConstrainDouble option with get, set
    abstract contrast: ConstrainDouble option with get, set
    abstract saturation: ConstrainDouble option with get, set
    abstract sharpness: ConstrainDouble option with get, set
    abstract focusDistance: ConstrainDouble option with get, set
    abstract zoom: ConstrainDouble option with get, set
    abstract torch: ConstrainBoolean option with get, set

type ImageMediaTrackSettings =
    inherit MediaTrackSettings
    abstract whiteBalanceMode: ShotMode
    abstract exposureMode: ShotMode
    abstract focusMode: ShotMode
    abstract pointsOfInterest: U2<PointsOfInterest array, PointsOfInterest> option
    abstract exposureCompensation: double option
    abstract colorTemperature: double option
    abstract iso: double option
    abstract brightness: double option
    abstract contrast: double option
    abstract saturation: double option
    abstract sharpness: double option
    abstract focusDistance: double option
    abstract zoom: double option
    abstract torch: bool option

[<StringEnum>]
type ResizeMode =
    | [<CompiledName("none")>] None'
    | [<CompiledName("crop-and-scale")>] CropAndScale

type ConstrainResizeMode = Constrain<ResizeMode>


[<StringEnum>]
type FacingMode =
    | User
    | Environment
    | Left
    | Right
type ConstrainFacingMode = Constrain<FacingMode>

type VideoMediaTrackConstraintSet =
    inherit MediaTrackConstraintSet
    abstract aspectRatio: ConstrainOrRangeDouble option with get, set
    abstract facingMode: ConstrainFacingMode option with get, set
    abstract frameRate: ConstrainOrRangeDouble option with get, set
    abstract height: ConstrainOrRangeULong option with get, set
    abstract width: ConstrainOrRangeULong option with get, set
    abstract resizeMode: ConstrainResizeMode option with get, set

type VideoMediaTrackSettings =
    inherit MediaTrackSettings
    abstract aspectRatio: float
    abstract facingMode: FacingMode
    abstract frameRate: double
    abstract height: uint32
    abstract width: uint32
    abstract resizeMode: ResizeMode

[<StringEnum>]
type Cursor =
    | Always
    | Motion
    | Never

type ConstrainCursor = Constrain<ResizeArray<Cursor>>

[<StringEnum>]
type DisplaySurface =
    | Application
    | Browser
    | Monitor
    | Window

type ConstrainDisplaySurface = Constrain<ResizeArray<DisplaySurface>>

type SharedScreenMediaTrackConstraintSet =
    inherit MediaTrackConstraintSet
    abstract cursor: ConstrainCursor option with get, set
    abstract displaySurface: ConstrainDisplaySurface option with get, set
    abstract logicalSurface: ConstrainBoolean option with get, set

type SharedScreenMediaTrackSettings =
    inherit MediaTrackSettings
    abstract cursor: Cursor
    abstract displaySurface: DisplaySurface
    abstract logicalSurface: bool


type MediaTrackConstraints =
    inherit MediaTrackConstraintSet
    abstract advanced: ResizeArray<MediaTrackConstraintSet> option with get, set

type VideoConstraints =
    inherit MediaTrackConstraintSet
    inherit ImageMediaTrackConstraintSet

// [<Erase>]
// type VideoMediaStreamConstraint =
// | Bool of bool
// | Camera of VideoConstraints

// [<Erase>]
// type AudioMediaStreamConstraint =
// | Bool of bool
// | Constraint of AudioMediaStreamConstraint


type StreamContraints =
    abstract video:obj with get, set
    abstract audio:obj with get, set

[<StringEnum>]
type TrackKind =
| Audio
| Video


[<StringEnum>]
type MediaStreamTrackState =
| Live
| Ended

type MediaTrackCapabilities =
    abstract width: ULongRange
    abstract height: ULongRange
    abstract aspectRatio: DoubleRange
    abstract frameRate: DoubleRange
    abstract facingMode: FacingMode array
    abstract resizeMode: ResizeMode array
    abstract sampleRate: ULongRange
    abstract sampleSize: ULongRange
    abstract echoCancellation: bool array
    abstract autoGainControl: bool array
    abstract noiseSuppression: bool array
    abstract latency: DoubleRange
    abstract channelCount: ULongRange
    abstract deviceId: string
    abstract groupId: string

type MediaStreamTrack =
    inherit EventTarget
    abstract kind: TrackKind
    abstract id: string
    abstract label: string
    abstract enabled: bool with get, set
    abstract muted: bool
    abstract onmute: (Event -> unit) with get, set
    abstract onunmute: (Event -> unit) with get, set
    abstract onended: (Event -> unit) with get, set
    abstract readyState: MediaStreamTrackState
    abstract clone: unit -> MediaStreamTrack
    abstract stop: unit -> unit
    abstract getCapabilities: unit -> MediaTrackCapabilities
    abstract getConstraints: unit -> MediaTrackConstraints
    abstract getSettings: unit -> MediaTrackSettings
    abstract applyConstraints: ?constraints:MediaTrackConstraints -> JS.Promise<unit>

type MediaStreamTrackEvent =
    abstract track: MediaStreamTrack

type AudioMediaStreamTrack =
    inherit MediaStreamTrack

type VideoMediaStreamTrack =
    inherit MediaStreamTrack


type MediaStream =
    inherit EventTarget
    abstract active: bool
    abstract id: string
    abstract onaddtrack: (MediaStreamTrackEvent->unit) with get, set
    abstract clone: unit -> MediaStream
    abstract getAudioTracks: unit -> AudioMediaStreamTrack array
    abstract getVideoTracks: unit -> VideoMediaStreamTrack array
    abstract getTrackById: string option -> MediaStreamTrack option
    abstract getTracks: unit -> MediaStreamTrack array
    abstract addTrack: track:#MediaStreamTrack -> unit
    abstract removeTrack: track:#MediaStreamTrack -> unit
    abstract onremovetrack: (MediaStreamTrackEvent->unit) with get, set

type MediaStreamType =
    [<Emit("new $0($1...)")>] abstract Create: unit -> MediaStream
    [<Emit("new $0($1...)")>] abstract Create: MediaStreamTrack array -> MediaStream

type CanvasCaptureMediaStreamTrack =
    inherit MediaStreamTrack
    abstract canvas: HTMLCanvasElement
    abstract requestFrame : unit -> unit

type MediaDeviceInfo =
    abstract deviceId: string
    abstract groupId: string
    abstract kind: string
    abstract label: string

type MediaDevices =
    inherit EventTarget
    abstract getSupportedConstraints: unit -> MediaTrackSupportedConstraints
    abstract getUserMedia: constraints: StreamContraints -> JS.Promise<MediaStream>
    abstract getDisplayMedia: constraints: SharedScreenMediaTrackConstraintSet option -> JS.Promise<MediaStream>
    abstract enumerateDevices: unit -> JS.Promise<ResizeArray<MediaDeviceInfo>>
    abstract ondevicechange: (Event->unit) with get, set


type StreamContraintsType =
    [<Emit("new Object({ video: $1, audio: $2 })")>]
    abstract Create: video : bool * audio : bool -> StreamContraints
    [<Emit("new Object({ video: $1, audio: $2 })")>]
    abstract Create: video : VideoConstraints * audio : bool -> StreamContraints
    [<Emit("new Object({ video: $1, audio: $2 })")>]
    abstract Create: video : VideoConstraints * audio : AudioConstraint -> StreamContraints
    [<Emit("new Object({ video: $1, audio: $2 })")>]
    abstract Create: video : bool * audio : AudioConstraint -> StreamContraints

type HTMLVideoElement' =
  inherit HTMLVideoElement
  abstract srcObject: MediaStream option with get, set

type HTMLAudioElement' =
  inherit HTMLAudioElement
  abstract srcObject: MediaStream option with get, set

namespace Browser

open Fable.Core

[<AutoOpenAttribute>]
module MediaStreams =
    open Browser.Types
    type HTMLCanvasElement with
        [<Emit("$0.captureStream({{$1}})")>]
        member __.captureStream(framerate:uint32 option) : MediaStreamTrack = failwith ""

    let [<Emit("navigator.mediaDevices")>] mediaDevices: MediaDevices = jsNative

    let [<Global>] MediaStream: MediaStreamType = jsNative

    let [<Global>] StreamContraints: StreamContraintsType = jsNative

[<RequireQualifiedAccess>]
module VideoConstraints =
    open Fable.Core.JsInterop
    open Browser.Types

    let Create (setter) =
        jsOptions<VideoConstraints> setter

[<RequireQualifiedAccess>]
module AudioConstraint =
    open Fable.Core.JsInterop
    open Browser.Types

    let Create (setter) =
        jsOptions<VideoConstraints> setter

