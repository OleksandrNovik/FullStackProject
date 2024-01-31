import Topic from "../../commonTypes/Topic";
import TopicContentSection from "./TopicContentSection";

interface TopicViewProps {
    isEditable: boolean;
    topic: Topic;
}

function TopicView({topic, isEditable}:TopicViewProps) {

    return <div>
        { isEditable ?  <input /> : <h1> {topic.name} </h1> }
        <TopicContentSection items={[
            {
                id: 1, type: 'header', innerText: 'HELLO'
            },
            {
                id: 2, type: 'text', innerText: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Nobis ipsum nam eligendi. Labore magnam, dolorum, quos suscipit obcaecati officiis nihil vero ea commodi ut omnis? Eum, minima? Minus, facere sed?'
            },
            {
                id: 2, type: 'code', innerText: 'function Play() {}'
            }
        ]} isEditable={isEditable} />
        { isEditable && <button> Save changes </button> }
    </div>
}

export default TopicView;