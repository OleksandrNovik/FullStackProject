import { FormEvent, useState } from "react";
import { topicTypeMap } from "../../../../../commonTypes/TopicElementInfo";

function TopicSectionSelector() {

    const [selectedType, setSelectedType] = useState('header');

    const handleSelect = ({currentTarget}:FormEvent<HTMLSelectElement>) => {
        setSelectedType(currentTarget.value);
    }

    return <section>
        <select value={selectedType} onChange={handleSelect}>
            { Object.keys(topicTypeMap)
                    .map(key => <option key={key} value={key}>{key}</option>)
            }
        </select>
        <button>+</button>
    </section>
}

export default TopicSectionSelector;