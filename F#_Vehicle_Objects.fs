
type Vehicle(vehicleName: string, speedMPH: int) = 

    member val VehicleName = vehicleName 
    member val SpeedMPH = speedMPH

    member this.GetName() = 
        this.VehicleName

type Dinterface = 
    abstract member Pdetails : unit -> string

type Land(vehicleName: string, speedMPH: int, wheelAmount: int, engineType: string, features:string) = 
    inherit Vehicle(vehicleName, speedMPH)
    member val WheelAmount = wheelAmount
    member val EngineType = engineType
    member val Features = features
    interface Dinterface with
        member this.Pdetails() = 
            if features = null || features = "null" then 
                sprintf "Land vehicle: %s \n Number of wheels: %d \n Engine type: %s \n Speed in MPH: %d \n\n" vehicleName wheelAmount engineType speedMPH 
            else 
                sprintf "Land vehicle: %s \n Number of wheels: %d \n Engine type: %s \n Speed in MPH: %d \n Special features: %s \n\n" vehicleName wheelAmount engineType speedMPH features

type Air(vehicleName: string, speedMPH: int, wheelspergear: int, flybywire: bool, enginetype: string, features: string) =
    inherit Vehicle(vehicleName, speedMPH)
    member val WheelsPerGear = wheelspergear
    member val FlyByWire = flybywire
    member val EngineType = enginetype
    member val Features = features
    interface Dinterface with
        member this.Pdetails() = 
            if features = null || features = "null" then 
                sprintf "Air vehicle: %s \n Number of wheels per landing gear: %d \n Fly by wire present?: %b \n Engine type: %s \n Speed in MPH: %d \n\n" vehicleName wheelspergear flybywire enginetype speedMPH 
            else 
                sprintf "Air vehicle: %s \n Number of wheels per landing gear: %d \n Fly by wire present?: %b \n Engine type: %s \n Speed in MPH: %d \n Special features: %s \n\n" vehicleName wheelspergear flybywire enginetype speedMPH features

type Sea(vehicleName: string, speedMPH: int, dryWeight: int, displacement: float, engineType: string, features:string) = 
    inherit Vehicle(vehicleName, speedMPH)
    member val DryWeight = dryWeight
    member val Displacement = displacement
    member val EngineType = engineType
    member val Features = features
    interface Dinterface with
        member this.Pdetails() = 
            if features = null || features = "null" then
                sprintf "Sea vehicle: %s \n Dry weight in pounds: %d \n Displacement in litres: %f \n Engine type: %s \n Speed in MPH: %d \n\n" vehicleName dryWeight displacement engineType speedMPH 
            else
                sprintf "Sea vehicle: %s \n Dry weight: %d \n Displacement: %f \n Engine type: %s \n Speed in MPH: %d \n Special features: %s \n\n" vehicleName dryWeight displacement engineType speedMPH features

open System

type Manufacturer() =
    
    let mutable seaVehicle = [] : Sea list
    let mutable airVehicle = [] : Air list
    let mutable landVehicle = [] : Land list

    static let mutable manuInstance = None
    static member Instance =
        match manuInstance with
        | Some value -> value
        | None -> 
            let value = new Manufacturer()
            manuInstance <- Some value
            value

    member this.AddSeaVehicle (vehicle:Sea) = seaVehicle <- vehicle :: seaVehicle
    member this.AddAirVehicle (vehicle:Air) = airVehicle <- vehicle :: airVehicle
    member this.AddLandVehicle (vehicle:Land) = landVehicle <- vehicle :: landVehicle

    member this.Pdetails() = 
        for vehicle in seaVehicle do
            printf "%s" ((vehicle :> Dinterface).Pdetails())
        for vehicle in airVehicle do
            printf "%s" ((vehicle :> Dinterface).Pdetails())
        for vehicle in landVehicle do
            printf "%s" ((vehicle :> Dinterface).Pdetails())


let main() = 
    
    let Sieghardware = Manufacturer()
    let SR71 = Air("SR-71", 3540, 3, true, "Turbojet-Ramjet hybrid", null)
    let Verge = Land("Verge Motorcycle", 112, 2, "Electric", "Hubless rear wheel (houses engine)")
    let CypressCay = Sea("Cypress Cay", 250, 3159, 0.2, "Gas", "Pontoon")
    Sieghardware.AddSeaVehicle(CypressCay)
    Sieghardware.AddLandVehicle(Verge)
    Sieghardware.AddAirVehicle(SR71)
    Sieghardware.Pdetails()


main()

