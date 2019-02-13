# Pipe[line] Dreams

I have opinions around automation, the following words are my attempts at organizing them...

## Abstract

Build pipelines **must be** fast so that developers are empowered to *continuously integrate* code. Release pipelines **must** promote artifacts that have passed through the build pipeline and prior release stages. This promotion ensures that work is not duplicated, and it provides a clear trail of where artifacts have been. A team may further enable their automation by leveraging continuous release, so that when artifacts have passed the required checks and gates, they can be deployed to their respective environments.

## Definitions

* CI: Continuous Integration
    * Enables teams to continuously integrate their changes in a controlled fashion.    
* Artifacts: 
    * The output of a CI pipeline (e.g. NuGet packages, dlls, executable applications, a zip of the CI workspace, etc.)
* CD: Continuous *Delivery*
    * Enables teams to continuously deliver their build artifacts to the appropriate destinations (i.e. package store, web app, database, etc.).  
* CR: Continuous Release
    * I believe I just made this up, but I wanted a term other than continuous deployment, as I chose CD to mean continuous delivery.
    * May be defined as Continuous Release to 'X', where 'X' is an environment such as Development, Stage, or Production.
    * An alternative to continuous releasing would be *gated* releasing.
    * For example, Continuously Releasing to development environments is common, whereas it is also common to have manual approvals before releasing an application to production environments.

## Standards

### CI Pipelines

Otherwise known as Build Pipelines.

* MAY contain reporting functionality as long as said functionality **does not** negatively impact pipeline completion times.
* MUST publish the result of the build in a location such that the CD pipeline can perform its necessary tasks.

### CD Pipelines

Otherwise known as Release Pipelines.

Continuous Delivery pipelines orchestrate the preparation and delivery of artifacts to the appropriate locations.

### CR enabled CD Pipelines

Or, Continuous Release enabled Continuous Delivery Pipelines. 

It may be a mouthful, but it could prove beneficial to stress the distinction that a team *can* continuously deliver artifacts *without* releasing/deploying them to a consumer. Thus, the automatic release/deployment of artifacts to the consumer would be considered Continuous Release, while having a gate that requires manual intervention in front of the release would be considered a Gated Release.

* To be considered a CR enabled CD Pipeline, the "Release" step **MUST BE** automated.