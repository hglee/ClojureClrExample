(ns ScriptNs)

(defn recv-bigseq [coll]
  (doseq [x (take 3 (drop 123456789 coll))]
    (prn x)))

(defn short-seq []
  (range 1024))

(defn big-seq[]
  (range))
