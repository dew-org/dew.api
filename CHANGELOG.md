# Changelog

## 1.0.0 (2022-12-18)


### Features

* add assembly helper ([b17dfed](https://github.com/dew-org/dew.api/commit/b17dfedf8e7d8fceba67556a4938840e3717c391))
* add initial command/query logic ([94d63a9](https://github.com/dew-org/dew.api/commit/94d63a967ac7e67e514755b17a069b79f2ae4335))
* add mongo db settings model ([4559280](https://github.com/dew-org/dew.api/commit/45592808dbb64b9c05dfb1603026c8aca7eb9222))
* add sealed modifier ([a588b3e](https://github.com/dew-org/dew.api/commit/a588b3e7e1a5ac9e9817330888f56976ce53e288))
* add shared project ([455cbd5](https://github.com/dew-org/dew.api/commit/455cbd5618be0c4aaade7fee4357d131844a6f50))
* add validation behaviour ([000766f](https://github.com/dew-org/dew.api/commit/000766fd70b7d5b4ce5eccf2557e943776ff0569))
* **catalogue:** add create product api endpoint ([cf93acb](https://github.com/dew-org/dew.api/commit/cf93acb1b330e451eb6849db0260cdb45a617fba))
* **catalogue:** add create product command validator ([a8c9e25](https://github.com/dew-org/dew.api/commit/a8c9e25a56eb608c2cf4a4e80343a357607ab4db))
* **catalogue:** add find product by code ([ff3c4f8](https://github.com/dew-org/dew.api/commit/ff3c4f8be22c54bbbd0cacf05379e884f94442e6))
* **catalogue:** add register product ([2c72e6c](https://github.com/dew-org/dew.api/commit/2c72e6c9afac8b4ee655fb8da8279fc0615ae9a9))
* **catalogue:** add search all products ([e552e05](https://github.com/dew-org/dew.api/commit/e552e054aae594ba318c0f9455f32dbb7c3cedea))
* **catalogue:** add search all products endpoint ([7c98328](https://github.com/dew-org/dew.api/commit/7c98328e8ca126e34acda6a12f9c65ba3779f4cd))
* **customers:** add cors policy ([22dc4cd](https://github.com/dew-org/dew.api/commit/22dc4cd557fa9fbab51aff1ff035f3150582c369))
* **customers:** add find customer by id ([9c2872b](https://github.com/dew-org/dew.api/commit/9c2872be6600399e8da2cb076836a654bad7e093))
* **customers:** add find customer endpoint ([11bbe74](https://github.com/dew-org/dew.api/commit/11bbe7499471ee6ab527e916f42bccfc46fc3d49))
* **customers:** add save customer api endpoint ([606f266](https://github.com/dew-org/dew.api/commit/606f266e91a68b742419361279a2767318a3cdf7))
* **customers:** add save support ([baab1e0](https://github.com/dew-org/dew.api/commit/baab1e0e28c82e301ebca4b719aee344a71d71d2))
* first commit ([78b5353](https://github.com/dew-org/dew.api/commit/78b5353d41fee5d3ee34f794ad11ade6ba9f2236))
* **inventory:** add save support ([#3](https://github.com/dew-org/dew.api/issues/3)) ([60b2c87](https://github.com/dew-org/dew.api/commit/60b2c8788b1b999712612c0ec544991ed1ecd91d))
* **inventory:** add update product stock ([#5](https://github.com/dew-org/dew.api/issues/5)) ([a3426fc](https://github.com/dew-org/dew.api/commit/a3426fc3b68ab7d4aa006eeab2a467c8efaec155))
* **inventory:** find product inventory by code or sku ([#4](https://github.com/dew-org/dew.api/issues/4)) ([f958bc2](https://github.com/dew-org/dew.api/commit/f958bc2fd41a7c4c723b8714ba651021d35a1481))
* **invoices:** add find functionality ([245b4bc](https://github.com/dew-org/dew.api/commit/245b4bc84a404083a31818f8e8bbcca0fab4b21b))
* **invoices:** add find support (only class on library) ([2883805](https://github.com/dew-org/dew.api/commit/2883805fd70c06815e26bb84e8e3db99a93f4ce5))
* **invoices:** add save endpoint ([abd1764](https://github.com/dew-org/dew.api/commit/abd176485d744e4d158dc8db234a7817176ab3fc))
* **invoices:** add save support (only on lib) ([d4c5fd8](https://github.com/dew-org/dew.api/commit/d4c5fd8d426edc6ebe074b173727c4f6009959b8))
* migrate all projects to .net7 ([b453678](https://github.com/dew-org/dew.api/commit/b453678d8829230183d2b0c1f2705f1e5e13dc4c))
* **shared:** add customers assembly ([b6c3724](https://github.com/dew-org/dew.api/commit/b6c3724c6966b3f1752efffc954bced15ca8ca25))
* **shared:** add mongo collection builder ([f03123f](https://github.com/dew-org/dew.api/commit/f03123f45e8de811eb6440a088cc70ed14524a9e))
* **shops:** add find by user id ([b18fe98](https://github.com/dew-org/dew.api/commit/b18fe98d6fc902decb8510751e2dd1bdae625b68))
* **shops:** add register support ([acfaf0e](https://github.com/dew-org/dew.api/commit/acfaf0e66bbb1ccfc7cd5ae2651f29646b42b3b0))


### Bug Fixes

* add missing project migration ([8cec759](https://github.com/dew-org/dew.api/commit/8cec75947e355b2b7dd6607df1df3eba707bf8e1))
* **invoices:** add missing properties and solve bugs ([75c3201](https://github.com/dew-org/dew.api/commit/75c3201f3975fc3275e9c6017180ef45cf783227))


### Build System

* add Mapster and MediatR packages ([f8e89bc](https://github.com/dew-org/dew.api/commit/f8e89bc81a8d7b4749386af7e5a8f9208dc6457b))
* bump missing projects to .net7 ([529bebe](https://github.com/dew-org/dew.api/commit/529bebec48c12b35d842599ae61eca2476f146c2))
* **catalogue:** set up Dockerfile ([fa568b3](https://github.com/dew-org/dew.api/commit/fa568b388f0c5f56028d4d970edd8b7dc81c08ec))
* **invoices:** update Dockerfile ([05f1889](https://github.com/dew-org/dew.api/commit/05f1889e4e79cfb880c31d49d01a684cd4049f35))
* **shared:** add FluentValidation and MongoDB.Driver packages ([61d5cfb](https://github.com/dew-org/dew.api/commit/61d5cfbb06bf5a749381307244f92dbe0704cefe))
* update Dockerfiles ([3d48c7c](https://github.com/dew-org/dew.api/commit/3d48c7c93463d360159220f5a8ee106c692f8ef0))
